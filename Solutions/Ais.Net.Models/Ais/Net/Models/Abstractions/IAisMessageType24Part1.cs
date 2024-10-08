﻿// <copyright file="IAisMessageType24Part1.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

public interface IAisMessageType24Part1
{
    uint MothershipMmsi { get; }

    uint SerialNumber { get; }

    uint Spare162 { get; }

    uint UnitModelCode { get; }

    string VendorIdRev3 { get; }

    string VendorIdRev4 { get; }
}