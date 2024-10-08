// <copyright file="AisMessageBase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Ais.Net.Models.Abstractions;

namespace Ais.Net.Models;

public record AisMessageBase(int MessageType, uint Mmsi) : IAisMessage;