// <copyright file="IAisMessageType5.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 5 (static and voyage related data).
/// </summary>
public interface IAisMessageType5
{
    /// <summary>
    /// Gets the AIS version indicator supported by the station.
    /// </summary>
    uint AisVersion { get; }

    /// <summary>
    /// Gets the destination of the voyage.
    /// </summary>
    string Destination { get; }

    /// <summary>
    /// Gets the maximum present static draught, expressed in tenths of a metre.
    /// </summary>
    uint Draught10thMetres { get; }

    /// <summary>
    /// Gets the month component of the estimated time of arrival (ETA).
    /// </summary>
    uint EtaMonth { get; }

    /// <summary>
    /// Gets the day component of the estimated time of arrival (ETA).
    /// </summary>
    uint EtaDay { get; }

    /// <summary>
    /// Gets the hour component of the estimated time of arrival (ETA).
    /// </summary>
    uint EtaHour { get; }

    /// <summary>
    /// Gets the minute component of the estimated time of arrival (ETA).
    /// </summary>
    uint EtaMinute { get; }

    /// <summary>
    /// Gets the IMO number identifying the vessel.
    /// </summary>
    uint ImoNumber { get; }

    /// <summary>
    /// Gets the spare value held in the bits at offset 423.
    /// </summary>
    uint Spare423 { get; }
}