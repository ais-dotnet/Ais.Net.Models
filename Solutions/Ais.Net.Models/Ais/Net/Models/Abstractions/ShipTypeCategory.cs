// <copyright file="ShipTypeCategory.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Coarse classification of a vessel derived from the AIS ship type code.
/// </summary>
public enum ShipTypeCategory
{
    /// <summary>
    /// No ship type category is available.
    /// </summary>
    NotAvailable = 0,

    /// <summary>
    /// Reserved for future use.
    /// </summary>
    Reserved = 1,

    /// <summary>
    /// Wing in ground (WIG) craft.
    /// </summary>
    WingInGround = 2,

    /// <summary>
    /// Special category reserved for the ship type code range beginning with 3.
    /// </summary>
    SpecialCategory3 = 3,

    /// <summary>
    /// High speed craft (HSC).
    /// </summary>
    HighSpeedCraft = 4,

    /// <summary>
    /// Special category reserved for the ship type code range beginning with 5.
    /// </summary>
    SpecialCategory5 = 5,

    /// <summary>
    /// Passenger vessel.
    /// </summary>
    Passenger = 6,

    /// <summary>
    /// Cargo vessel.
    /// </summary>
    Cargo = 7,

    /// <summary>
    /// Tanker.
    /// </summary>
    Tanker = 8,

    /// <summary>
    /// Other type of vessel.
    /// </summary>
    Other = 9
}