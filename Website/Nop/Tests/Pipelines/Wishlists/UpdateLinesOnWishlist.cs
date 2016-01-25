﻿// ----------------------------------------------------------------------------------------------
// <copyright file="AddLinesToCartTest.cs" company="Sitecore Corporation">
//     Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// <summary>
//   Defines the AddLinesToCartTest type.
// </summary>
// ----------------------------------------------------------------------------------------------
// Copyright 2016 Sitecore Corporation A/S
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file 
// except in compliance with the License. You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the 
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
// either express or implied. See the License for the specific language governing permissions 
// and limitations under the License.
// ---------------------------------------------------------------------
namespace Sitecore.Commerce.Connectors.NopCommerce.Tests.Pipelines.Wishlists
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using FluentAssertions;
  using NSubstitute;
  using Sitecore.Commerce.Connectors.NopCommerce;
  using Sitecore.Commerce.Pipelines;
  using Xunit;
  using Sitecore.Commerce.Services.WishLists;
  using Sitecore.Commerce.Connectors.NopCommerce.NopWishlistsService;
  using Sitecore.Commerce.Connectors.NopCommerce.Pipelines.Wishlists.AddLinesToWishlist;
  using Sitecore.Commerce.Connectors.NopCommerce.Pipelines.Wishlists.UpdateLinesOnWishlist;
  using Sitecore.Commerce.Connectors.NopCommerce.Tests.Pipelines.Carts.AddCartLines;
  using Sitecore.Commerce.Entities.Carts;
  using Sitecore.Commerce.Entities.Prices;
  using Sitecore.Commerce.Entities.WishLists;

  /// <summary>
  /// The update lines to wishlist test.
  /// </summary>
  public class UpdateLinesOnWishlistTest
  {
    /// <summary>
    /// The processor.
    /// </summary>
    private readonly UpdateLinesOnWishlist processor;

    /// <summary>
    /// The visitor id.
    /// </summary>
    private readonly Guid visitorId;

    /// <summary>
    /// The request.
    /// </summary>
    private readonly UpdateWishListLinesRequest request;

    /// <summary>
    /// The result.
    /// </summary>
    private readonly UpdateWishListLinesResult result;

    /// <summary>
    /// The args.
    /// </summary>
    private readonly ServicePipelineArgs args;

    /// <summary>
    /// The client.
    /// </summary>
    private readonly IWishlistsServiceChannel client;

    /// <summary>
    /// The wishlist.
    /// </summary>
    private readonly WishList wishlist;

    /// <summary>
    /// The wishlist.
    /// </summary>
    private readonly WishList updatedWishlist;

    /// <summary>
    /// The old line.
    /// </summary>
    private readonly WishListLine oldLine;

    /// <summary>
    /// The update line.
    /// </summary>
    private readonly WishListLine lineToUpdate;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateLinesOnWishlistTest"/> class.
    /// </summary>
    public UpdateLinesOnWishlistTest()
    {
      this.visitorId = Guid.NewGuid();

      this.oldLine = new WishListLine()
      {
        ExternalId = "10",
        Product = new CartProduct
        {
          ProductId = "100500",
          Price = new Price { Amount = 100 }
        },
        Quantity = 12
      };

      this.lineToUpdate = new WishListLine()
      {
        ExternalId = "10",
        Product = new CartProduct
        {
          ProductId = "100500",
          Price = new Price { Amount = 100 }
        },
        Quantity = 2
      };

      this.wishlist = new WishList
      {
        ExternalId = this.visitorId.ToString(),
        Lines = new ReadOnlyCollection<WishListLine>(new List<WishListLine> { this.oldLine })
      };

      this.updatedWishlist = new WishList
      {
        ExternalId = this.visitorId.ToString(),
        Lines = new ReadOnlyCollection<WishListLine>(new List<WishListLine> { this.lineToUpdate })
      };

      this.request = new UpdateWishListLinesRequest(this.wishlist, new[] { this.lineToUpdate });
      this.result = new UpdateWishListLinesResult();
      this.args = new ServicePipelineArgs(this.request, this.result);

      this.client = Substitute.For<IWishlistsServiceChannel>();

      var clientFactory = Substitute.For<ServiceClientFactory>();
      clientFactory.CreateClient<IWishlistsServiceChannel>(Arg.Any<string>(), Arg.Any<string>()).Returns(this.client);

      this.processor = new UpdateLinesOnWishlist { ClientFactory = clientFactory };
    }

    /// <summary>
    /// Should add lines to wishlist.
    /// </summary>
    [Fact]
    public void ShouldUpdateLinesOnWishlist()
    {
      // arrange
      var inintialLineModel = new ShoppingCartItemModel();
      var initialCartModel = new ShoppingCartModel { ShoppingItems = new[] { inintialLineModel } };
      this.client.GetWishlist(this.visitorId).Returns(initialCartModel);

      this.client.UpdateQuantity(this.visitorId, "100500", 2).Returns(initialCartModel);

      // act
      this.processor.Process(this.args);

      // assert
      this.result.UpdatedLines.Count.Should().Be(1);
      this.result.UpdatedLines.First().Product.ProductId.Should().Be("100500");
      this.result.UpdatedLines.First().Quantity.Should().Be(2);
    }
  }
}