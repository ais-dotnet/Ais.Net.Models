namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class PositionTests
{
    [TestMethod]
    [DataRow(600000, 1.0)]      // 1 degree == 60 minutes == 600,000 ten-thousandths of a minute
    [DataRow(-600000, -1.0)]
    [DataRow(300000, 0.5)]
    [DataRow(0, 0.0)]
    public void From10000thMinsToDegreesScalesBySixHundredThousand(int tenThousandthsOfMinutes, double expectedDegrees)
    {
        tenThousandthsOfMinutes.From10000thMinsToDegrees().ShouldBe(expectedDegrees);
    }

    [TestMethod]
    [DataRow(600, 1.0)]         // 1 degree == 60 minutes == 600 tenths of a minute
    [DataRow(-600, -1.0)]
    [DataRow(300, 0.5)]
    [DataRow(0, 0.0)]
    public void From10thMinsToDegreesScalesBySixHundred(int tenthsOfMinutes, double expectedDegrees)
    {
        tenthsOfMinutes.From10thMinsToDegrees().ShouldBe(expectedDegrees);
    }

    [TestMethod]
    public void From10000thMinsBuildsPositionFromScaledLatitudeAndLongitude()
    {
        Position position = Position.From10000thMins(600000, 1200000);

        position.ShouldBe(new Position(1.0, 2.0));
    }

    [TestMethod]
    public void From10thMinsBuildsPositionFromScaledLatitudeAndLongitude()
    {
        Position position = Position.From10thMins(600, 1200);

        position.ShouldBe(new Position(1.0, 2.0));
    }

    [TestMethod]
    [DataRow(54600000, 91.0)]       // AIS "latitude not available" sentinel (91 degrees)
    [DataRow(108600000, 181.0)]     // AIS "longitude not available" sentinel (181 degrees)
    public void From10000thMinsToDegreesDoesNotSpecialCaseNotAvailableSentinels(int tenThousandthsOfMinutes, double expectedDegrees)
    {
        // Unlike speed/course, the coordinate helpers do not null out the "not available"
        // sentinels; the raw out-of-range degrees pass straight through (any such filtering
        // is the caller's / decoder's responsibility).
        tenThousandthsOfMinutes.From10000thMinsToDegrees().ShouldBe(expectedDegrees);
    }

    [TestMethod]
    public void PositionsWithTheSameCoordinatesAreEqual()
    {
        new Position(51.5, -0.12).ShouldBe(new Position(51.5, -0.12));
    }

    [TestMethod]
    public void PositionsWithDifferentCoordinatesAreNotEqual()
    {
        new Position(51.5, -0.12).ShouldNotBe(new Position(51.5, 0.12));
    }
}
