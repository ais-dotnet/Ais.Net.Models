// <copyright file="AisMessageBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System;

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// The abstract base for all AIS messages, carrying the fields common to every message type.
/// </summary>
/// <param name="MessageType">The AIS message type identifier.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
public record AisMessageBase(int MessageType, uint Mmsi) : IAisMessage, IAisTimestamp
{
    /// <summary>
    /// Gets the time the message was received or recorded, or <see langword="null"/> when the
    /// source did not supply one. Set it in the object initialiser when constructing a message.
    /// </summary>
    public DateTimeOffset? Timestamp { get; init; }
}
