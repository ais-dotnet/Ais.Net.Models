// <copyright file="IAisMessageType24Part0.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Describes the properties specific to an AIS message type 24 Part A (static data report carrying the vessel name).
/// </summary>
public interface IAisMessageType24Part0
{
    /// <summary>
    /// Gets the spare value held in the bits at offset 160.
    /// </summary>
    uint Spare160 { get; }
}