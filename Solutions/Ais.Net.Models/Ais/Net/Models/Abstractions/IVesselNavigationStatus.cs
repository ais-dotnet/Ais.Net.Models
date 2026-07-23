// <copyright file="IVesselNavigationStatus.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's navigation status.
/// </summary>
public interface IVesselNavigationStatus
{
    /// <summary>
    /// Gets the vessel's navigation status.
    /// </summary>
    NavigationStatus NavigationStatus { get; }
}