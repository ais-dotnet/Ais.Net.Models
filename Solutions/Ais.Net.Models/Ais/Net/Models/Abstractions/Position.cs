// <copyright file="Position.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Ais.Net.Models.Abstractions;

/// <summary>
/// A geographic position expressed as latitude and longitude in degrees.
/// </summary>
/// <param name="Latitude">The latitude in degrees (positive north of the equator).</param>
/// <param name="Longitude">The longitude in degrees (positive east of the prime meridian).</param>
/// <remarks>
/// This is a value type so that a decoded position incurs no heap allocation; on the AIS decode
/// path this avoids one allocation per positional message.
/// </remarks>
public readonly record struct Position(double Latitude, double Longitude)
{
    /// <summary>
    /// Creates a <see cref="Position"/> from coordinates expressed in ten-thousandths of a minute
    /// (the encoding used by most AIS position reports).
    /// </summary>
    /// <param name="latitude">The latitude in units of 1/10000 minute.</param>
    /// <param name="longitude">The longitude in units of 1/10000 minute.</param>
    /// <returns>The position in degrees.</returns>
    public static Position From10000thMins(int latitude, int longitude) =>
        new (latitude.From10000thMinsToDegrees(), longitude.From10000thMinsToDegrees());

    /// <summary>
    /// Creates a <see cref="Position"/> from coordinates expressed in tenths of a minute (the
    /// lower-precision encoding used by the long-range message type 27).
    /// </summary>
    /// <param name="latitude">The latitude in units of 1/10 minute.</param>
    /// <param name="longitude">The longitude in units of 1/10 minute.</param>
    /// <returns>The position in degrees.</returns>
    public static Position From10thMins(int latitude, int longitude) =>
        new(latitude.From10thMinsToDegrees(), longitude.From10thMinsToDegrees());
}
