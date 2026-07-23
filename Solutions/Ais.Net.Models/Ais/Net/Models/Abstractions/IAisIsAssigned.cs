// <copyright file="IAisIsAssigned.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the AIS assigned-mode status flag.
/// </summary>
public interface IAisIsAssigned
{
    /// <summary>
    /// Gets a value indicating whether the station is operating in assigned mode.
    /// </summary>
    bool IsAssigned { get; }
}