// <copyright file="AisMessageType24Part0.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

public record AisMessageType24Part0(
    uint Mmsi,
    uint PartNumber,
    uint RepeatIndicator,
    uint Spare160) :
    AisMessageBase(MessageType: 24, Mmsi),
    IAisMultipartMessage,
    IRepeatIndicator,
    IAisMessageType24Part0;