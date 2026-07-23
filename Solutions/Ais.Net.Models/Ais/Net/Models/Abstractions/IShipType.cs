// <copyright file="IShipType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the ship-and-cargo type.
/// </summary>
public interface IShipType
{
    /// <summary>
    /// Gets the ship-and-cargo type of the vessel.
    /// </summary>
    ShipType ShipType { get; }
}