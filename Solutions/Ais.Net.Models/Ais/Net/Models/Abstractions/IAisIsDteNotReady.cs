// <copyright file="IAisIsDteNotReady.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the AIS data terminal equipment (DTE) readiness status flag.
/// </summary>
public interface IAisIsDteNotReady
{
    /// <summary>
    /// Gets a value indicating whether the data terminal equipment (DTE) is not ready.
    /// </summary>
    bool IsDteNotReady { get; }
}