// <copyright file="IVesselName.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's name.
/// </summary>
public interface IVesselName
{
    /// <summary>
    /// Gets the vessel's name.
    /// </summary>
    string VesselName { get; }
}