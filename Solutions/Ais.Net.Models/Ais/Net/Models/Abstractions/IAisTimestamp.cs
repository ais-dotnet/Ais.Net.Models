// <copyright file="IAisTimestamp.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using System;

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// Exposes the time at which a message was received or recorded, when the source supplies one.
/// </summary>
/// <remarks>
/// An AIS message does not itself carry a full date and time: the position reports carry only the
/// UTC second of the minute (see <see cref="IVesselNavigation.TimeStampSecond"/>). The timestamp
/// comes from whatever delivered the message, such as the NMEA tag block written by a receiving
/// station, or the record time in an archived data set.
/// </remarks>
public interface IAisTimestamp
{
    /// <summary>
    /// Gets the time the message was received or recorded, or <see langword="null"/> when the
    /// source did not supply one.
    /// </summary>
    DateTimeOffset? Timestamp { get; }
}
