// <copyright file="IVesselDimensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's dimensions, measured in metres from the position reference point.
/// </summary>
public interface IVesselDimensions
{
    /// <summary>
    /// Gets the distance in metres from the position reference point to the bow of the vessel.
    /// </summary>
    uint DimensionToBow { get; }

    /// <summary>
    /// Gets the distance in metres from the position reference point to the port side of the vessel.
    /// </summary>
    uint DimensionToPort { get; }

    /// <summary>
    /// Gets the distance in metres from the position reference point to the starboard side of the vessel.
    /// </summary>
    uint DimensionToStarboard { get; }

    /// <summary>
    /// Gets the distance in metres from the position reference point to the stern of the vessel.
    /// </summary>
    uint DimensionToStern { get; }
}