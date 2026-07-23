// <copyright file="AisMessageType5.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// Static and voyage related data (AIS message type 5).
/// </summary>
/// <param name="AisVersion">The AIS station compliance version.</param>
/// <param name="CallSign">The call sign of the vessel.</param>
/// <param name="Destination">The destination of the current voyage.</param>
/// <param name="DimensionToBow">The distance in metres from the position reference point to the bow.</param>
/// <param name="DimensionToPort">The distance in metres from the position reference point to the port side.</param>
/// <param name="DimensionToStarboard">The distance in metres from the position reference point to the starboard side.</param>
/// <param name="DimensionToStern">The distance in metres from the position reference point to the stern.</param>
/// <param name="Draught10thMetres">The maximum present static draught in 1/10 metre.</param>
/// <param name="EtaDay">The day component of the estimated time of arrival.</param>
/// <param name="EtaHour">The hour component of the estimated time of arrival.</param>
/// <param name="EtaMinute">The minute component of the estimated time of arrival.</param>
/// <param name="EtaMonth">The month component of the estimated time of arrival.</param>
/// <param name="IsDteNotReady">Whether the Data Terminal Equipment is not ready.</param>
/// <param name="ImoNumber">The IMO ship identification number.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="PositionFixType">The electronic position fixing device type.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="ShipType">The ship-and-cargo type code.</param>
/// <param name="Spare423">The value of the spare bits at bit offset 423.</param>
/// <param name="VesselName">The name of the vessel.</param>
public sealed record AisMessageType5(
    uint AisVersion,
    string CallSign,
    string Destination,
    uint DimensionToBow,
    uint DimensionToPort,
    uint DimensionToStarboard,
    uint DimensionToStern,
    uint Draught10thMetres,
    uint EtaDay,
    uint EtaHour,
    uint EtaMinute,
    uint EtaMonth,
    bool IsDteNotReady,
    uint ImoNumber,
    uint Mmsi,
    EpfdFixType PositionFixType,
    uint RepeatIndicator,
    ShipType ShipType,
    uint Spare423,
    string VesselName) :
    AisMessageBase(MessageType: 5, Mmsi),
    IAisMessageType5,
    IAisIsDteNotReady,
    IAisPositionFixType,
    ICallSign,
    IRepeatIndicator,
    IShipType,
    IVesselDimensions,
    IVesselName;