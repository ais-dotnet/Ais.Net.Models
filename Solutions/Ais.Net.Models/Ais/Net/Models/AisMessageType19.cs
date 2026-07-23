// <copyright file="AisMessageType19.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// A Class B "SO" extended position report (AIS message type 19).
/// </summary>
/// <param name="CourseOverGround">The course over ground in degrees, or null when not available.</param>
/// <param name="DimensionToBow">The distance in metres from the position reference point to the bow.</param>
/// <param name="DimensionToPort">The distance in metres from the position reference point to the port side.</param>
/// <param name="DimensionToStarboard">The distance in metres from the position reference point to the starboard side.</param>
/// <param name="DimensionToStern">The distance in metres from the position reference point to the stern.</param>
/// <param name="IsAssigned">Whether the station is operating in assigned mode.</param>
/// <param name="IsDteNotReady">Whether the Data Terminal Equipment is not ready.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="Position">The reported latitude/longitude, or null when not available.</param>
/// <param name="PositionAccuracy">Whether a high-accuracy (DGPS) fix is indicated.</param>
/// <param name="PositionFixType">The electronic position fixing device type.</param>
/// <param name="RaimFlag">Whether Receiver Autonomous Integrity Monitoring is in use.</param>
/// <param name="RegionalReserved139">The value of the regional reserved bits at bit offset 139.</param>
/// <param name="RegionalReserved38">The value of the regional reserved bits at bit offset 38.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="ShipName">The name of the vessel.</param>
/// <param name="ShipType">The ship-and-cargo type code.</param>
/// <param name="Spare308">The value of the spare bits at bit offset 308.</param>
/// <param name="SpeedOverGround">The speed over ground in knots, or null when not available.</param>
/// <param name="TimeStampSecond">The UTC second when the report was generated.</param>
/// <param name="TrueHeadingDegrees">The true heading in degrees.</param>
public record AisMessageType19(
    float? CourseOverGround,
    uint DimensionToBow,
    uint DimensionToPort,
    uint DimensionToStarboard,
    uint DimensionToStern,
    bool IsAssigned,
    bool IsDteNotReady,
    uint Mmsi,
    Position? Position,
    bool PositionAccuracy,
    EpfdFixType PositionFixType,
    bool RaimFlag,
    int RegionalReserved139,
    int RegionalReserved38,
    uint RepeatIndicator,
    string ShipName,
    ShipType ShipType,
    uint Spare308,
    float? SpeedOverGround,
    uint TimeStampSecond,
    uint TrueHeadingDegrees) :
    AisMessageBase(MessageType: 19, Mmsi),
    IAisMessageType19,
    IAisIsAssigned,
    IAisIsDteNotReady,
    IAisPositionFixType,
    IRaimFlag,
    IRepeatIndicator,
    IShipType,
    IVesselDimensions,
    IVesselNavigation;