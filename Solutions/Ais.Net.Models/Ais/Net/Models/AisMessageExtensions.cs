// <copyright file="AisMessageExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System;
using System.Text;
using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// Helper methods for converting raw AIS field values into the units and types exposed by the
/// model records, and for classifying ship-type codes.
/// </summary>
public static class AisMessageExtensions
{
    /// <summary>
    /// Converts a coordinate expressed in ten-thousandths of a minute (the encoding used by most
    /// AIS position reports) to degrees.
    /// </summary>
    /// <param name="value">The coordinate in units of 1/10000 minute.</param>
    /// <returns>The coordinate in degrees.</returns>
    public static double From10000thMinsToDegrees(this int value)
    {
        return value / 600000.0;
    }

    /// <summary>
    /// Converts a coordinate expressed in tenths of a minute (the lower-precision encoding used by
    /// the long-range message type 27) to degrees.
    /// </summary>
    /// <param name="value">The coordinate in units of 1/10 minute.</param>
    /// <returns>The coordinate in degrees.</returns>
    public static double From10thMinsToDegrees(this int value)
    {
        return value / 600.0;
    }

    /// <summary>
    /// Converts a value expressed in tenths (for example speed over ground in 1/10 knot) to its
    /// real value, treating the sentinel 1023 as "not available".
    /// </summary>
    /// <param name="value">The raw value in tenths.</param>
    /// <returns>The scaled value, or <see langword="null"/> when the value is the 1023 "not available" sentinel.</returns>
    public static float? FromTenths(this uint value)
    {
        return value == 1023 ? null : (value / 10.0f);
    }

    /// <summary>
    /// Converts a value expressed in tenths of a degree (for example course over ground) to
    /// degrees, treating the sentinel 3600 as "not available".
    /// </summary>
    /// <param name="value">The raw value in tenths of a degree.</param>
    /// <returns>The value in degrees, or <see langword="null"/> when the value is the 3600 "not available" sentinel.</returns>
    public static float? FromTenthsToDegrees(this uint value)
    {
        return value == 3600 ? null : (value / 10.0f);
    }

    /// <summary>
    /// Removes the '@' and space padding that AIS applies to text name fields and collapses any
    /// run of interior spaces to a single space, preserving significant single spaces (such as in
    /// "QUEEN MARY 2").
    /// </summary>
    /// <param name="value">The raw, padded vessel name.</param>
    /// <returns>The cleaned vessel name, or an empty string when the input is entirely padding.</returns>
    public static string CleanVesselName(this string value)
    {
        // AIS pads names with '@' (6-bit value 0) and/or spaces. Strip that padding from both
        // ends (order-independently) and collapse any run of interior spaces to a single space
        // (a single interior space is significant, e.g. "QUEEN MARY 2"). The result is built
        // through a stack buffer so that only the returned string is allocated.
        ReadOnlySpan<char> trimmed = value.AsSpan().Trim("@ ");
        if (trimmed.IsEmpty)
        {
            return string.Empty;
        }

        // AIS text fields are short (<= 20 chars); the heap fallback guards against a pathological
        // caller passing an over-long string to what is otherwise a stackalloc.
        Span<char> buffer = trimmed.Length <= 256 ? stackalloc char[256] : new char[trimmed.Length];
        int length = 0;
        bool previousWasSpace = false;
        foreach (char c in trimmed)
        {
            bool isSpace = c == ' ';
            if (isSpace && previousWasSpace)
            {
                continue;
            }

            buffer[length++] = c;
            previousWasSpace = isSpace;
        }

        return new string(buffer[..length]);
    }

    /// <summary>
    /// Decodes a span of ASCII bytes to a string.
    /// </summary>
    /// <param name="value">The ASCII bytes to decode.</param>
    /// <returns>The decoded string.</returns>
    public static string GetString(this ReadOnlySpan<byte> value)
    {
        return Encoding.ASCII.GetString(value);
    }

    /// <summary>
    /// Decodes an AIS 6-bit ASCII text field to a string.
    /// </summary>
    /// <param name="field">The parser positioned over the text field.</param>
    /// <returns>The decoded text.</returns>
    public static string TextFieldToString(this NmeaAisTextFieldParser field)
    {
        int characterCount = (int)field.CharacterCount;

        // AIS text fields are short; the heap fallback guards against a field that reports a
        // pathologically large character count from overflowing the stack.
        Span<byte> ascii = characterCount <= 256 ? stackalloc byte[256] : new byte[characterCount];
        Span<byte> field6BitAscii = ascii[..characterCount];
        field.WriteAsAscii(field6BitAscii);

        return Encoding.ASCII.GetString(field6BitAscii);
    }

    /// <summary>
    /// Maps a ship-and-cargo type to its coarse <see cref="ShipTypeCategory"/>.
    /// </summary>
    /// <param name="shipType">The ship type.</param>
    /// <returns>The category the ship type belongs to.</returns>
    public static ShipTypeCategory ToShipTypeCategory(this ShipType shipType)
    {
        return shipType.ToShipTypeGroup().ToShipTypeCategory();
    }

    /// <summary>
    /// Maps a <see cref="ShipTypeGroup"/> to its coarse <see cref="ShipTypeCategory"/>.
    /// </summary>
    /// <param name="shipTypeGroup">The ship-type group.</param>
    /// <returns>The category the group belongs to.</returns>
    public static ShipTypeCategory ToShipTypeCategory(this ShipTypeGroup shipTypeGroup)
    {
        return shipTypeGroup switch
        {
            ShipTypeGroup.NotAvailable => ShipTypeCategory.NotAvailable,
            ShipTypeGroup.Reserved => ShipTypeCategory.Reserved,
            ShipTypeGroup.WingInGroundAll => ShipTypeCategory.WingInGround,
            ShipTypeGroup.WingInGroundHazardous => ShipTypeCategory.WingInGround,
            ShipTypeGroup.WingInGroundReserved => ShipTypeCategory.WingInGround,
            ShipTypeGroup.Fishing => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.Towing => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.TowingLengthOver200MOrBreadthOver25M => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.DredgingOrUnderwaterOps => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.DivingOps => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.MilitaryOps => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.Sailing => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.PleasureCraft => ShipTypeCategory.SpecialCategory3,
            ShipTypeGroup.HighSpeedCraftAll => ShipTypeCategory.HighSpeedCraft,
            ShipTypeGroup.HighSpeedCraftHazardous => ShipTypeCategory.HighSpeedCraft,
            ShipTypeGroup.HighSpeedCraftReserved => ShipTypeCategory.HighSpeedCraft,
            ShipTypeGroup.HighSpeedCraftNoAdditionalInformation => ShipTypeCategory.HighSpeedCraft,
            ShipTypeGroup.PilotVessel => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.SearchAndRescueVessel => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.Tug => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.PortTender => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.AntiPollutionEquipment => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.LawEnforcement => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.SpareLocalVessel => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.MedicalTransport => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.NoncombatantShip => ShipTypeCategory.SpecialCategory5,
            ShipTypeGroup.PassengerAll => ShipTypeCategory.Passenger,
            ShipTypeGroup.PassengerHazardous => ShipTypeCategory.Passenger,
            ShipTypeGroup.PassengerReserved => ShipTypeCategory.Passenger,
            ShipTypeGroup.PassengerNoAdditionalInformation => ShipTypeCategory.Passenger,
            ShipTypeGroup.CargoAll => ShipTypeCategory.Cargo,
            ShipTypeGroup.CargoHazardous => ShipTypeCategory.Cargo,
            ShipTypeGroup.CargoReserved => ShipTypeCategory.Cargo,
            ShipTypeGroup.CargoNoAdditionalInformation => ShipTypeCategory.Cargo,
            ShipTypeGroup.TankerAll => ShipTypeCategory.Tanker,
            ShipTypeGroup.TankerHazardous => ShipTypeCategory.Tanker,
            ShipTypeGroup.TankerReserved => ShipTypeCategory.Tanker,
            ShipTypeGroup.TankerNoAdditionalInformation => ShipTypeCategory.Tanker,
            ShipTypeGroup.OtherAll => ShipTypeCategory.Other,
            ShipTypeGroup.OtherHazardous => ShipTypeCategory.Other,
            ShipTypeGroup.OtherReserved => ShipTypeCategory.Other,
            ShipTypeGroup.OtherNoAdditionalInformation => ShipTypeCategory.Other,
            _ => ShipTypeCategory.NotAvailable,
        };
    }

    /// <summary>
    /// Returns the human-readable description for a raw ship-and-cargo type code.
    /// </summary>
    /// <param name="shipType">The raw ship-type code (0-99).</param>
    /// <returns>The description, or "Not available" when the code is out of range.</returns>
    public static string ToShipTypeDescription(this int shipType)
    {
        return (uint)shipType < (uint)ShipTypeTable.Length
            ? ShipTypeTable[shipType].Description
            : NotAvailableDescription;
    }

    /// <summary>
    /// Maps a ship-and-cargo type to its <see cref="ShipTypeGroup"/>.
    /// </summary>
    /// <param name="shipType">The ship type.</param>
    /// <returns>The group the ship type belongs to.</returns>
    public static ShipTypeGroup ToShipTypeGroup(this ShipType shipType)
    {
        return ToShipTypeGroup((int)shipType);
    }

    /// <summary>
    /// Maps a raw ship-and-cargo type code to its <see cref="ShipTypeGroup"/>.
    /// </summary>
    /// <param name="shipType">The raw ship-type code (0-99).</param>
    /// <returns>The group the code belongs to, or <see cref="ShipTypeGroup.NotAvailable"/> when the code is out of range.</returns>
    public static ShipTypeGroup ToShipTypeGroup(this int shipType)
    {
        return (uint)shipType < (uint)ShipTypeTable.Length
            ? ShipTypeTable[shipType].Group
            : ShipTypeGroup.NotAvailable;
    }

    private const string NotAvailableDescription = "Not available";

    // Single source of truth for ship-type classification: each raw code (0-99) is mapped to its
    // group AND its human-readable description in exactly one place, so they can never disagree.
    // (A previous bug had code 49 classified as "reserved" by the group switch while the separate
    // description switch said "no additional information".) Category is derived from the group, so
    // all three facets flow from this one table.
    private static readonly ShipTypeInfo[] ShipTypeTable = BuildShipTypeTable();

    private static ShipTypeInfo[] BuildShipTypeTable()
    {
        ShipTypeInfo[] table = new ShipTypeInfo[100];
        for (int i = 0; i < table.Length; i++)
        {
            table[i] = new ShipTypeInfo(ShipTypeGroup.NotAvailable, NotAvailableDescription);
        }

        SetRange(table, 1, 19, ShipTypeGroup.Reserved, "Reserved for future use");

        // Wing in ground (20-29): note this band has no "no additional information" code.
        table[20] = new ShipTypeInfo(ShipTypeGroup.WingInGroundAll, "Wing in ground(WIG), all ships of this type");
        SetHazardousCategories(table, 21, ShipTypeGroup.WingInGroundHazardous, "Wing in ground(WIG)");
        SetRange(table, 25, 29, ShipTypeGroup.WingInGroundReserved, "Wing in ground(WIG), Reserved for future use");

        table[30] = new ShipTypeInfo(ShipTypeGroup.Fishing, "Fishing");
        table[31] = new ShipTypeInfo(ShipTypeGroup.Towing, "Towing");
        table[32] = new ShipTypeInfo(ShipTypeGroup.TowingLengthOver200MOrBreadthOver25M, "Towing: length exceeds 200m or breadth exceeds 25m");
        table[33] = new ShipTypeInfo(ShipTypeGroup.DredgingOrUnderwaterOps, "Dredging or underwater ops");
        table[34] = new ShipTypeInfo(ShipTypeGroup.DivingOps, "Diving ops");
        table[35] = new ShipTypeInfo(ShipTypeGroup.MilitaryOps, "Military ops");
        table[36] = new ShipTypeInfo(ShipTypeGroup.Sailing, "Sailing");
        table[37] = new ShipTypeInfo(ShipTypeGroup.PleasureCraft, "Pleasure Craft");
        SetRange(table, 38, 39, ShipTypeGroup.Reserved, "Reserved");

        // High speed craft (40-49): code 49 is "no additional information", not reserved.
        table[40] = new ShipTypeInfo(ShipTypeGroup.HighSpeedCraftAll, "High speed craft(HSC), all ships of this type");
        SetHazardousCategories(table, 41, ShipTypeGroup.HighSpeedCraftHazardous, "High speed craft(HSC)");
        SetRange(table, 45, 48, ShipTypeGroup.HighSpeedCraftReserved, "High speed craft(HSC), Reserved for future use");
        table[49] = new ShipTypeInfo(ShipTypeGroup.HighSpeedCraftNoAdditionalInformation, "High speed craft(HSC), No additional information");

        table[50] = new ShipTypeInfo(ShipTypeGroup.PilotVessel, "Pilot Vessel");
        table[51] = new ShipTypeInfo(ShipTypeGroup.SearchAndRescueVessel, "Search and Rescue vessel");
        table[52] = new ShipTypeInfo(ShipTypeGroup.Tug, "Tug");
        table[53] = new ShipTypeInfo(ShipTypeGroup.PortTender, "Port Tender");
        table[54] = new ShipTypeInfo(ShipTypeGroup.AntiPollutionEquipment, "Anti - pollution equipment");
        table[55] = new ShipTypeInfo(ShipTypeGroup.LawEnforcement, "Law Enforcement");
        SetRange(table, 56, 57, ShipTypeGroup.SpareLocalVessel, "Spare - Local Vessel");
        table[58] = new ShipTypeInfo(ShipTypeGroup.MedicalTransport, "Medical Transport");
        table[59] = new ShipTypeInfo(ShipTypeGroup.NoncombatantShip, "Noncombatant ship according to RR Resolution No. 18");

        // Passenger (60-69).
        table[60] = new ShipTypeInfo(ShipTypeGroup.PassengerAll, "Passenger, all ships of this type");
        SetHazardousCategories(table, 61, ShipTypeGroup.PassengerHazardous, "Passenger");
        SetRange(table, 65, 68, ShipTypeGroup.PassengerReserved, "Passenger, Reserved for future use");
        table[69] = new ShipTypeInfo(ShipTypeGroup.PassengerNoAdditionalInformation, "Passenger, No additional information");

        // Cargo (70-79).
        table[70] = new ShipTypeInfo(ShipTypeGroup.CargoAll, "Cargo, all ships of this type");
        SetHazardousCategories(table, 71, ShipTypeGroup.CargoHazardous, "Cargo");
        SetRange(table, 75, 78, ShipTypeGroup.CargoReserved, "Cargo, Reserved for future use");
        table[79] = new ShipTypeInfo(ShipTypeGroup.CargoNoAdditionalInformation, "Cargo, No additional information");

        // Tanker (80-89).
        table[80] = new ShipTypeInfo(ShipTypeGroup.TankerAll, "Tanker, all ships of this type");
        SetHazardousCategories(table, 81, ShipTypeGroup.TankerHazardous, "Tanker");
        SetRange(table, 85, 88, ShipTypeGroup.TankerReserved, "Tanker, Reserved for future use");
        table[89] = new ShipTypeInfo(ShipTypeGroup.TankerNoAdditionalInformation, "Tanker, No additional information");

        // Other (90-99): code 99 uses lowercase "no additional information" in the source data.
        table[90] = new ShipTypeInfo(ShipTypeGroup.OtherAll, "Other Type, all ships of this type");
        SetHazardousCategories(table, 91, ShipTypeGroup.OtherHazardous, "Other Type");
        SetRange(table, 95, 98, ShipTypeGroup.OtherReserved, "Other Type, Reserved for future use");
        table[99] = new ShipTypeInfo(ShipTypeGroup.OtherNoAdditionalInformation, "Other Type, no additional information");

        return table;
    }

    private static void SetHazardousCategories(ShipTypeInfo[] table, int firstCode, ShipTypeGroup group, string descriptionPrefix)
    {
        // The four consecutive codes map to "Hazardous category A" through "Hazardous category D".
        for (int i = 0; i < 4; i++)
        {
            table[firstCode + i] = new ShipTypeInfo(group, $"{descriptionPrefix}, Hazardous category {(char)('A' + i)}");
        }
    }

    private static void SetRange(ShipTypeInfo[] table, int firstCode, int lastCode, ShipTypeGroup group, string description)
    {
        for (int i = firstCode; i <= lastCode; i++)
        {
            table[i] = new ShipTypeInfo(group, description);
        }
    }

    private readonly record struct ShipTypeInfo(ShipTypeGroup Group, string Description);
}
