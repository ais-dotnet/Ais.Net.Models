// <copyright file="AisMessageType24Part1.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// A static data report, Part B - type, dimensions and identifiers (AIS message type 24, part 1).
/// </summary>
/// <param name="CallSign">The call sign of the vessel.</param>
/// <param name="DimensionToBow">The distance in metres from the position reference point to the bow.</param>
/// <param name="DimensionToPort">The distance in metres from the position reference point to the port side.</param>
/// <param name="DimensionToStarboard">The distance in metres from the position reference point to the starboard side.</param>
/// <param name="DimensionToStern">The distance in metres from the position reference point to the stern.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="MothershipMmsi">The MMSI of the mothership for an auxiliary craft.</param>
/// <param name="PartNumber">The part number identifying this as Part B of the static data report.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="SerialNumber">The equipment serial number of the Class B unit.</param>
/// <param name="Spare162">The value of the spare bits at bit offset 162.</param>
/// <param name="ShipType">The ship-and-cargo type code.</param>
/// <param name="UnitModelCode">The unit model code of the Class B equipment.</param>
/// <param name="VendorIdRev3">The vendor identifier as encoded under revision 3 of the specification.</param>
/// <param name="VendorIdRev4">The vendor identifier as encoded under revision 4 of the specification.</param>
public record AisMessageType24Part1(
    string CallSign,
    uint DimensionToBow,
    uint DimensionToPort,
    uint DimensionToStarboard,
    uint DimensionToStern,
    uint Mmsi,
    uint MothershipMmsi,
    uint PartNumber,
    uint RepeatIndicator,
    uint SerialNumber,
    uint Spare162,
    ShipType ShipType,
    uint UnitModelCode,
    string VendorIdRev3,
    string VendorIdRev4) :
    AisMessageBase(MessageType: 24, Mmsi),
    IAisMessageType24Part1,
    IAisMultipartMessage,
    ICallSign,
    IRepeatIndicator,
    IShipType,
    IVesselDimensions;