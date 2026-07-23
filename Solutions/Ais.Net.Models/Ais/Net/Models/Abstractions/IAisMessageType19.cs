// <copyright file="IAisMessageType19.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 19 (Class B "SO" extended position report).
/// </summary>
public interface IAisMessageType19
{
    /// <summary>
    /// Gets the regional reserved value held in the bits at offset 139.
    /// </summary>
    int RegionalReserved139 { get; }

    /// <summary>
    /// Gets the regional reserved value held in the bits at offset 38.
    /// </summary>
    int RegionalReserved38 { get; }

    /// <summary>
    /// Gets the name of the ship.
    /// </summary>
    string ShipName { get; }

    /// <summary>
    /// Gets the spare value held in the bits at offset 308.
    /// </summary>
    uint Spare308 { get; }
}