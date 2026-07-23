// <copyright file="IVesselNavigation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's navigation data, including position, course, speed and heading.
/// </summary>
public interface IVesselNavigation: IVesselPositionAccuracy, IVesselSpeedOverGround, IVesselCourseOverGround
{
    /// <summary>
    /// Gets the vessel's position, or null when not available.
    /// </summary>
    Position? Position { get; }

    /// <summary>
    /// Gets the UTC second at which the position was reported.
    /// </summary>
    uint TimeStampSecond { get; }

    /// <summary>
    /// Gets the vessel's true heading in degrees.
    /// </summary>
    uint TrueHeadingDegrees { get; }
}