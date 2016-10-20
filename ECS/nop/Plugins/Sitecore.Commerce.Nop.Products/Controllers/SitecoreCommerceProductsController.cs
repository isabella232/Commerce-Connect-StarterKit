﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SitecoreCommerceProductsController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// <summary>Defines the SitecoreCommerceProductsController class.</summary>
// --------------------------------------------------------------------------------------------------------------------
// Copyright 2016 Sitecore Corporation A/S
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file 
// except in compliance with the License. You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the 
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
// either express or implied. See the License for the specific language governing permissions 
// and limitations under the License.
// -----------------------------------------------------------------
namespace Sitecore.Commerce.Nop.Products.Controllers
{
    using System.Web.Mvc;
    using global::Nop.Web.Framework.Controllers;

    /// <summary>
    /// The products controller.
    /// </summary>
    [AdminAuthorize]
    public class SitecoreCommerceProductsController : Controller
    {
        /// <summary>
        /// Configures the controller.
        /// </summary>
        /// <returns>The action result.</returns>
        public ActionResult Configure()
        {
            return this.View("Sitecore.Commerce.Nop.Products.Views.CommerceProducts.Configure");
        }
    }
}