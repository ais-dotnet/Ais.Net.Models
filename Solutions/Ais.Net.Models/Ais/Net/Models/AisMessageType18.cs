// <copyright file="AisMessageType18.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// A Class B "CS" (carrier-sense) position report (AIS message type 18).
/// </summary>
/// <param name="CanAcceptMessage22ChannelAssignment">Whether the unit can accept a channel assignment via message type 22.</param>
/// <param name="CanSwitchBands">Whether the unit can switch frequency bands.</param>
/// <param name="CourseOverGround">The course over ground in degrees, or null when not available.</param>
/// <param name="CsUnit">The Class B unit type (carrier-sense or SOTDMA).</param>
/// <param name="HasDisplay">Whether the unit is equipped with a display.</param>
/// <param name="IsAssigned">Whether the station is operating in assigned mode.</param>
/// <param name="IsDscAttached">Whether the unit is attached to a Digital Selective Calling (DSC) transceiver.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="Position">The reported latitude/longitude, or null when not available.</param>
/// <param name="PositionAccuracy">Whether a high-accuracy (DGPS) fix is indicated.</param>
/// <param name="RadioStatusType">The type of radio status information carried by the message.</param>
/// <param name="RaimFlag">Whether Receiver Autonomous Integrity Monitoring is in use.</param>
/// <param name="RegionalReserved139">The value of the regional reserved bits at bit offset 139.</param>
/// <param name="RegionalReserved38">The value of the regional reserved bits at bit offset 38.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="SpeedOverGround">The speed over ground in knots, or null when not available.</param>
/// <param name="TimeStampSecond">The UTC second when the report was generated.</param>
/// <param name="TrueHeadingDegrees">The true heading in degrees.</param>
public record AisMessageType18(
    bool CanAcceptMessage22ChannelAssignment,
    bool CanSwitchBands,
    float? CourseOverGround,
    ClassBUnit CsUnit,
    bool HasDisplay,
    bool IsAssigned,
    bool IsDscAttached,
    uint Mmsi,
    Position? Position,
    bool PositionAccuracy,
    ClassBRadioStatusType RadioStatusType,
    bool RaimFlag,
    int RegionalReserved139,
    int RegionalReserved38,
    uint RepeatIndicator,
    float? SpeedOverGround,
    uint TimeStampSecond,
    uint TrueHeadingDegrees) :
    AisMessageBase(MessageType: 18, Mmsi),
    IAisMessageType18,
    IAisIsAssigned,
    IRaimFlag,
    IRepeatIndicator,
    IVesselNavigation;