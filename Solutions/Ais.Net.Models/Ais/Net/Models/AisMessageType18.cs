// <copyright file="AisMessageType18.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

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