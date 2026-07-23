// <copyright file="IAisMessage.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Common abstraction for an AIS message, combining vessel identity with the message type identifier.
/// </summary>
public interface IAisMessage : IVesselIdentity, IAisMessageType
{
}