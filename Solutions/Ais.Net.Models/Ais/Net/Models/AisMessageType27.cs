// <copyright file="AisMessageType27.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

public record AisMessageType27(
    float? CourseOverGround,
    bool GnssPositionStatus,
    uint Mmsi,
    NavigationStatus NavigationStatus,
    Position? Position,
    bool PositionAccuracy,
    bool RaimFlag,
    uint RepeatIndicator,
    float? SpeedOverGround) :
    AisMessageBase(MessageType: 27, Mmsi),
    IAisMessageType27,
    IRaimFlag,
    IRepeatIndicator,
    IVesselCourseOverGround,
    IVesselNavigationStatus,
    IVesselPositionAccuracy;