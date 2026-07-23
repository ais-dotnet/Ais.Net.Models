// <copyright file="AisMessageBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// The abstract base for all AIS messages, carrying the fields common to every message type.
/// </summary>
/// <param name="MessageType">The AIS message type identifier.</param>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
public record AisMessageBase(int MessageType, uint Mmsi) : IAisMessage;