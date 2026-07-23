// <copyright file="IAisMessageType18.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 18 (Class B "CS" position report).
/// </summary>
public interface IAisMessageType18
{
    /// <summary>
    /// Gets a value indicating whether the unit can accept a channel assignment via a message type 22.
    /// </summary>
    bool CanAcceptMessage22ChannelAssignment { get; }

    /// <summary>
    /// Gets a value indicating whether the unit can switch frequency bands.
    /// </summary>
    bool CanSwitchBands { get; }

    /// <summary>
    /// Gets the Class B carrier sense (CS) unit type.
    /// </summary>
    ClassBUnit CsUnit { get; }

    /// <summary>
    /// Gets a value indicating whether the unit has a display.
    /// </summary>
    bool HasDisplay { get; }

    /// <summary>
    /// Gets a value indicating whether a digital selective calling (DSC) transceiver is attached.
    /// </summary>
    bool IsDscAttached { get; }

    /// <summary>
    /// Gets the Class B radio status type indicating how the radio status field is encoded.
    /// </summary>
    ClassBRadioStatusType RadioStatusType { get; }

    /// <summary>
    /// Gets the regional reserved value held in the bits at offset 139.
    /// </summary>
    int RegionalReserved139 { get; }

    /// <summary>
    /// Gets the regional reserved value held in the bits at offset 38.
    /// </summary>
    int RegionalReserved38 { get; }
}