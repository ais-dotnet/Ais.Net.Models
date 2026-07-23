// <copyright file="IAisPositionFixType.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the electronic position fixing device (EPFD) type used by the vessel.
/// </summary>
public interface IAisPositionFixType
{
    /// <summary>
    /// Gets the type of electronic position fixing device (EPFD) used to obtain the position fix.
    /// </summary>
    EpfdFixType PositionFixType { get; }
}