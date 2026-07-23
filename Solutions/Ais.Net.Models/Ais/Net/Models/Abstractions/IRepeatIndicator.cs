// <copyright file="IRepeatIndicator.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes how many times the message has been repeated by a repeater.
/// </summary>
public interface IRepeatIndicator
{
    /// <summary>
    /// Gets the number of times the message has been repeated by a repeater.
    /// </summary>
    uint RepeatIndicator { get; }
}