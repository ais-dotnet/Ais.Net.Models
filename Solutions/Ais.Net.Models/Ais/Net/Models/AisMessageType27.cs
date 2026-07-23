// <copyright file="AisMessageType27.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// A long-range AIS broadcast position message (AIS message type 27).
/// </summary>
/// <param name="CourseOverGround">The course over ground in degrees, or null when not available.</param>
/// <param name="GnssPositionStatus">Whether the position was obtained from the on-board GNSS receiver.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="NavigationStatus">The reported navigation status of the vessel.</param>
/// <param name="Position">The reported latitude/longitude, or null when not available.</param>
/// <param name="PositionAccuracy">Whether a high-accuracy (DGPS) fix is indicated.</param>
/// <param name="RaimFlag">Whether Receiver Autonomous Integrity Monitoring is in use.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="SpeedOverGround">The speed over ground in knots, or null when not available.</param>
public sealed record AisMessageType27(
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