// <copyright file="IVesselIdentity.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's identity.
/// </summary>
public interface IVesselIdentity
{
    /// <summary>
    /// Gets the vessel's Maritime Mobile Service Identity (MMSI).
    /// </summary>
    uint Mmsi { get; }
}