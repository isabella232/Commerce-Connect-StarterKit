﻿// --------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Sitecore Corporation">
//     Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// <summary>
//   HomeController class
// </summary>
// --------------------------------------------------------------------
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
namespace Sitecore.Commerce.StarterKit.Services
{
  using System.Collections.Generic;
  using Entities;
  using Entities.Payments;
  using Entities.Shipping;

  /// <summary>
  /// The CheckoutService interface.
  /// </summary>
  public interface ICheckoutService
  {
    /// <summary>
    /// Get shipping options
    /// </summary>
    /// <returns>
    /// The shipping optins
    /// </returns>
    IEnumerable<ShippingOption> GetShippingOptions();

    /// <summary>
    /// Get payment options
    /// </summary>
    /// <returns>
    /// The payment options
    /// </returns>
    IEnumerable<PaymentOption> GetPaymentOptions();

    /// <summary>
    /// Get shipping methods
    /// </summary>
    /// <param name="shippingOption"></param>
    /// <returns></returns>
    IEnumerable<ShippingMethod> GetShippingMethods(ShippingOption shippingOption);

    /// <summary>
    /// Get payment methods
    /// </summary>
    /// <param name="paymentOption"></param>
    /// <returns></returns>
    IEnumerable<PaymentMethod> GetPaymentMethods(PaymentOption paymentOption);
  }
}