// <copyright file="ShipTypeGroup.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Fine-grained grouping of a vessel derived from the AIS ship type code.
/// </summary>
public enum ShipTypeGroup
{
    /// <summary>
    /// No ship type group is available.
    /// </summary>
    NotAvailable,

    /// <summary>
    /// Reserved for future use.
    /// </summary>
    Reserved,

    /// <summary>
    /// Wing in ground craft, all ships of this type.
    /// </summary>
    WingInGroundAll,

    /// <summary>
    /// Wing in ground craft carrying hazardous or polluting cargo.
    /// </summary>
    WingInGroundHazardous,

    /// <summary>
    /// Wing in ground craft, reserved for future use.
    /// </summary>
    WingInGroundReserved,

    /// <summary>
    /// Fishing vessel.
    /// </summary>
    Fishing,

    /// <summary>
    /// Vessel engaged in towing.
    /// </summary>
    Towing,

    /// <summary>
    /// Vessel engaged in towing where the tow exceeds 200 metres in length or 25 metres in breadth.
    /// </summary>
    TowingLengthOver200MOrBreadthOver25M,

    /// <summary>
    /// Vessel engaged in dredging or underwater operations.
    /// </summary>
    DredgingOrUnderwaterOps,

    /// <summary>
    /// Vessel engaged in diving operations.
    /// </summary>
    DivingOps,

    /// <summary>
    /// Vessel engaged in military operations.
    /// </summary>
    MilitaryOps,

    /// <summary>
    /// Sailing vessel.
    /// </summary>
    Sailing,

    /// <summary>
    /// Pleasure craft.
    /// </summary>
    PleasureCraft,

    /// <summary>
    /// High speed craft, all ships of this type.
    /// </summary>
    HighSpeedCraftAll,

    /// <summary>
    /// High speed craft carrying hazardous or polluting cargo.
    /// </summary>
    HighSpeedCraftHazardous,

    /// <summary>
    /// High speed craft, reserved for future use.
    /// </summary>
    HighSpeedCraftReserved,

    /// <summary>
    /// High speed craft with no additional information.
    /// </summary>
    HighSpeedCraftNoAdditionalInformation,

    /// <summary>
    /// Pilot vessel.
    /// </summary>
    PilotVessel,

    /// <summary>
    /// Search and rescue vessel.
    /// </summary>
    SearchAndRescueVessel,

    /// <summary>
    /// Tug.
    /// </summary>
    Tug,

    /// <summary>
    /// Port tender.
    /// </summary>
    PortTender,

    /// <summary>
    /// Vessel carrying anti-pollution equipment.
    /// </summary>
    AntiPollutionEquipment,

    /// <summary>
    /// Law enforcement vessel.
    /// </summary>
    LawEnforcement,

    /// <summary>
    /// Spare, reserved for local or regional vessel assignments.
    /// </summary>
    SpareLocalVessel,

    /// <summary>
    /// Medical transport.
    /// </summary>
    MedicalTransport,

    /// <summary>
    /// Ship or aircraft not party to an armed conflict (noncombatant).
    /// </summary>
    NoncombatantShip,

    /// <summary>
    /// Passenger vessel, all ships of this type.
    /// </summary>
    PassengerAll,

    /// <summary>
    /// Passenger vessel carrying hazardous or polluting cargo.
    /// </summary>
    PassengerHazardous,

    /// <summary>
    /// Passenger vessel, reserved for future use.
    /// </summary>
    PassengerReserved,

    /// <summary>
    /// Passenger vessel with no additional information.
    /// </summary>
    PassengerNoAdditionalInformation,

    /// <summary>
    /// Cargo vessel, all ships of this type.
    /// </summary>
    CargoAll,

    /// <summary>
    /// Cargo vessel carrying hazardous or polluting cargo.
    /// </summary>
    CargoHazardous,

    /// <summary>
    /// Cargo vessel, reserved for future use.
    /// </summary>
    CargoReserved,

    /// <summary>
    /// Cargo vessel with no additional information.
    /// </summary>
    CargoNoAdditionalInformation,

    /// <summary>
    /// Tanker, all ships of this type.
    /// </summary>
    TankerAll,

    /// <summary>
    /// Tanker carrying hazardous or polluting cargo.
    /// </summary>
    TankerHazardous,

    /// <summary>
    /// Tanker, reserved for future use.
    /// </summary>
    TankerReserved,

    /// <summary>
    /// Tanker with no additional information.
    /// </summary>
    TankerNoAdditionalInformation,

    /// <summary>
    /// Other type of vessel, all ships of this type.
    /// </summary>
    OtherAll,

    /// <summary>
    /// Other type of vessel carrying hazardous or polluting cargo.
    /// </summary>
    OtherHazardous,

    /// <summary>
    /// Other type of vessel, reserved for future use.
    /// </summary>
    OtherReserved,

    /// <summary>
    /// Other type of vessel with no additional information.
    /// </summary>
    OtherNoAdditionalInformation,
}