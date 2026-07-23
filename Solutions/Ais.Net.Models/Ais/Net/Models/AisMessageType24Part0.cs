// <copyright file="AisMessageType24Part0.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

/// <summary>
/// A static data report, Part A - the vessel name (AIS message type 24, part 0).
/// </summary>
/// <param name="Mmsi">The Maritime Mobile Service Identity of the transmitting station.</param>
/// <param name="PartNumber">The part number identifying this as Part A of the static data report.</param>
/// <param name="RepeatIndicator">The number of times the message has been repeated.</param>
/// <param name="Spare160">The value of the spare bits at bit offset 160.</param>
public sealed record AisMessageType24Part0(
    uint Mmsi,
    uint PartNumber,
    uint RepeatIndicator,
    uint Spare160) :
    AisMessageBase(MessageType: 24, Mmsi),
    IAisMultipartMessage,
    IRepeatIndicator,
    IAisMessageType24Part0;