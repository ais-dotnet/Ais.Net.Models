// <copyright file="IVesselCourseOverGround.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's course over ground.
/// </summary>
public interface IVesselCourseOverGround
{
    /// <summary>
    /// Gets the course over ground in degrees, or null when not available.
    /// </summary>
    float? CourseOverGround { get; }
}