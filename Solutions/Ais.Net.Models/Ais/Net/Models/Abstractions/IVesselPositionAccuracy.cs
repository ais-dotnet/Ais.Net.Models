// <copyright file="IVesselPositionAccuracy.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes whether a high-accuracy (DGPS) position fix is indicated.
/// </summary>
public interface IVesselPositionAccuracy
{
    /// <summary>
    /// Gets a value indicating whether a high-accuracy (DGPS) position fix is indicated.
    /// </summary>
    bool PositionAccuracy { get; }
}