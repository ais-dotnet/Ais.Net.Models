// <copyright file="IVesselNavigation.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

public interface IVesselNavigation: IVesselPositionAccuracy, IVesselSpeedOverGround, IVesselCourseOverGround
{
    Position? Position { get; }

    uint TimeStampSecond { get; }

    uint TrueHeadingDegrees { get; }
}