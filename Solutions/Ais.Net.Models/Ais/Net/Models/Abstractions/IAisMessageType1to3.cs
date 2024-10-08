﻿// <copyright file="IAisMessageType1to3.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

public interface IAisMessageType1to3
{
    ManoeuvreIndicator ManoeuvreIndicator { get; }

    uint RadioSlotTimeout { get; }

    uint RadioSubMessage { get; }

    RadioSyncState RadioSyncState { get; }

    int RateOfTurn { get; }

    uint SpareBits145 { get; }
}