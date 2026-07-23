// <copyright file="AisMessageType1Through3.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// A Class A vessel position report (AIS message types 1, 2 and 3).
/// </summary>
/// <param name="CourseOverGround">The course over ground in degrees, or null when not available.</param>
/// <param name="ManoeuvreIndicator">The special manoeuvre indicator for the vessel.</param>
/// <param name="MessageType">The AIS message type identifier.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="NavigationStatus">The reported navigation status of the vessel.</param>
/// <param name="Position">The reported latitude/longitude, or null when not available.</param>
/// <param name="PositionAccuracy">Whether a high-accuracy (DGPS) fix is indicated.</param>
/// <param name="RadioSlotTimeout">The number of remaining transmission slots before the radio slot timeout.</param>
/// <param name="RadioSubMessage">The radio sub-message value, whose meaning depends on the radio slot timeout.</param>
/// <param name="RadioSyncState">The synchronisation state of the radio.</param>
/// <param name="RateOfTurn">The rate of turn of the vessel.</param>
/// <param name="RaimFlag">Whether Receiver Autonomous Integrity Monitoring is in use.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="SpareBits145">The value of the spare bits at bit offset 145.</param>
/// <param name="SpeedOverGround">The speed over ground in knots, or null when not available.</param>
/// <param name="TimeStampSecond">The UTC second when the report was generated.</param>
/// <param name="TrueHeadingDegrees">The true heading in degrees.</param>
public sealed record AisMessageType1Through3(
    float? CourseOverGround,
    ManoeuvreIndicator ManoeuvreIndicator,
    int MessageType,
    uint Mmsi,
    NavigationStatus NavigationStatus,
    Position? Position,
    bool PositionAccuracy,
    uint RadioSlotTimeout,
    uint RadioSubMessage,
    RadioSyncState RadioSyncState,
    int RateOfTurn,
    bool RaimFlag,
    uint RepeatIndicator,
    uint SpareBits145,
    float? SpeedOverGround,
    uint TimeStampSecond,
    uint TrueHeadingDegrees) :
    AisMessageBase(MessageType, Mmsi),
    IAisMessageType1to3,
    IRaimFlag,
    IRepeatIndicator,
    IVesselNavigation,
    IVesselNavigationStatus;