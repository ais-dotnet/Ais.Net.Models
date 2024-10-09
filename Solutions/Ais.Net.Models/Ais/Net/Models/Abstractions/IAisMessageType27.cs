// <copyright file="IAisMessageType27.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

public interface IAisMessageType27
{
    bool GnssPositionStatus { get; }

    Position? Position { get; }
}