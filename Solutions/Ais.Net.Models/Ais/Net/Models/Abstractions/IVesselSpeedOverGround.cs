// <copyright file="IVesselSpeedOverGround.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's speed over ground.
/// </summary>
public interface IVesselSpeedOverGround
{
    /// <summary>
    /// Gets the speed over ground in knots, or null when not available.
    /// </summary>
    float? SpeedOverGround { get; }
}