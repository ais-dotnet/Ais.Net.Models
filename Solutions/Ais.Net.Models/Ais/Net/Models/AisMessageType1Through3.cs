﻿// <copyright file="AisMessageType1Through3.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

public record AisMessageType1Through3(
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