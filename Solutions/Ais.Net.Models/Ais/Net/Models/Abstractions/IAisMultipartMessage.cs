// <copyright file="IAisMultipartMessage.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Marks an AIS message that is split across multiple parts.
/// </summary>
public interface IAisMultipartMessage
{
    /// <summary>
    /// Gets the zero-based part number identifying this part of the multipart message.
    /// </summary>
    uint PartNumber { get; }
}