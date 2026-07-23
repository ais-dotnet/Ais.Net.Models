// <copyright file="IAisMessageType24Part1.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 24 Part B (static data report carrying vessel dimensions and equipment details).
/// </summary>
public interface IAisMessageType24Part1
{
    /// <summary>
    /// Gets the MMSI of the mothership associated with this unit.
    /// </summary>
    uint MothershipMmsi { get; }

    /// <summary>
    /// Gets the manufacturer-assigned serial number of the unit.
    /// </summary>
    uint SerialNumber { get; }

    /// <summary>
    /// Gets the spare value held in the bits at offset 162.
    /// </summary>
    uint Spare162 { get; }

    /// <summary>
    /// Gets the manufacturer-assigned unit model code.
    /// </summary>
    uint UnitModelCode { get; }

    /// <summary>
    /// Gets the vendor identifier as interpreted under ITU-R M.1371 revision 3.
    /// </summary>
    string VendorIdRev3 { get; }

    /// <summary>
    /// Gets the vendor identifier as interpreted under ITU-R M.1371 revision 4.
    /// </summary>
    string VendorIdRev4 { get; }
}