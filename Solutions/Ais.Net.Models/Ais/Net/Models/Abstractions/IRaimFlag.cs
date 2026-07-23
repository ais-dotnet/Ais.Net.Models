// <copyright file="IRaimFlag.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes whether Receiver Autonomous Integrity Monitoring (RAIM) is in use.
/// </summary>
public interface IRaimFlag
{
    /// <summary>
    /// Gets a value indicating whether Receiver Autonomous Integrity Monitoring (RAIM) is in use by the position fixing device.
    /// </summary>
    bool RaimFlag { get; }
}