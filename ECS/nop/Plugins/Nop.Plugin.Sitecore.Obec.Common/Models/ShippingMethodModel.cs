﻿// -----------------------------------------------------------------
// <copyright file="ShippingMethodModel.cs" company="Sitecore Corporation">
//     Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// <summary>
//   Defines the ShippingMethodModel type.
// </summary>
// -----------------------------------------------------------------
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
namespace Nop.Plugin.Sitecore.Commerce.Common.Models
{
  using System.Runtime.Serialization;

  /// <summary>
  /// Shipping method model
  /// </summary>
  [DataContract]
  public class ShippingMethodModel
  {
    /// <summary>
    /// Name
    /// </summary>
    [DataMember]
    public string Name { get; set; }

    /// <summary>
    /// System name
    /// </summary>
    [DataMember]
    public string SystemName { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [DataMember]
    public string Description { get; set; }
  }
}