﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommercePlugin.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// <summary>
//   Entry point for Commerce plugin.
// </summary>
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
namespace Sitecore.Commerce.Nop.Carts
{
  using System.Web.Routing;
  using global::Nop.Core.Plugins;
  using global::Nop.Services.Common;

  /// <summary>
  /// Entry point for Commerce plugin.
  /// </summary>
  public class CommercePlugin : BasePlugin, IMiscPlugin
  {
    /// <summary>
    /// The get configuration route.
    /// </summary>
    /// <param name="actionName">
    /// The action name.
    /// </param>
    /// <param name="controllerName">
    /// The controller name.
    /// </param>
    /// <param name="routeValues">
    /// The route values.
    /// </param>
    public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
    {
      actionName = "Configure";
      controllerName = "SitecoreCommerceCarts";
      routeValues = new RouteValueDictionary { { "Namespaces", "Sitecore.Commerce.Nop.Carts.Controllers" }, { "area", null } };
    }
  }
}