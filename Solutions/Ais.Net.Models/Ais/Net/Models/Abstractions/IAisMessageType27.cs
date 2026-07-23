// <copyright file="IAisMessageType27.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 27 (long-range broadcast position report).
/// </summary>
public interface IAisMessageType27
{
    /// <summary>
    /// Gets a value indicating whether the GNSS position is being reported by the position system.
    /// </summary>
    bool GnssPositionStatus { get; }

    /// <summary>
    /// Gets the reported position of the vessel, or <see langword="null"/> if no position is available.
    /// </summary>
    Position? Position { get; }
}