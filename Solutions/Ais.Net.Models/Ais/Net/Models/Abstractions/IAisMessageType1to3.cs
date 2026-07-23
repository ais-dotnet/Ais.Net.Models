// <copyright file="IAisMessageType1to3.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 1, 2 or 3 (Class A position report).
/// </summary>
public interface IAisMessageType1to3
{
    /// <summary>
    /// Gets the special manoeuvre indicator for the vessel.
    /// </summary>
    ManoeuvreIndicator ManoeuvreIndicator { get; }

    /// <summary>
    /// Gets the number of frames remaining until the transmission slot times out.
    /// </summary>
    uint RadioSlotTimeout { get; }

    /// <summary>
    /// Gets the radio sub-message, whose meaning depends on the slot timeout value.
    /// </summary>
    uint RadioSubMessage { get; }

    /// <summary>
    /// Gets the radio synchronisation state.
    /// </summary>
    RadioSyncState RadioSyncState { get; }

    /// <summary>
    /// Gets the rate of turn of the vessel.
    /// </summary>
    int RateOfTurn { get; }

    /// <summary>
    /// Gets the spare value held in the bits at offset 145.
    /// </summary>
    uint SpareBits145 { get; }
}