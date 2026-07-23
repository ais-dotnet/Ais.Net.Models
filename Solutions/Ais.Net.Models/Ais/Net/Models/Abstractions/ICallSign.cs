// <copyright file="ICallSign.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the vessel's radio call sign.
/// </summary>
public interface ICallSign
{
    /// <summary>
    /// Gets the vessel's radio call sign.
    /// </summary>
    string CallSign { get; }
}