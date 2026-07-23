// <copyright file="IAisMessageType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the numeric AIS message type identifier.
/// </summary>
public interface IAisMessageType
{
    /// <summary>
    /// Gets the numeric AIS message type identifier.
    /// </summary>
    int MessageType { get; }
}