using System;

using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

namespace Ais.Net.Models.Specs;

[TestClass]
public class AisMessageBaseTests
{
    private static readonly DateTimeOffset ReceivedAt = new(2026, 1, 1, 0, 0, 3, TimeSpan.Zero);

    [TestMethod]
    public void TimestampIsNullWhenNotSupplied()
    {
        AisMessageBase message = new(MessageType: 27, Mmsi: 123456789);

        message.Timestamp.ShouldBeNull();
    }

    [TestMethod]
    public void TimestampCanBeSetInTheObjectInitialiser()
    {
        AisMessageType27 message = CreateType27(ReceivedAt);

        message.Timestamp.ShouldBe(ReceivedAt);
    }

    [TestMethod]
    public void TimestampIsExposedThroughIAisTimestamp()
    {
        IAisMessage message = CreateType27(ReceivedAt);

        IAisTimestamp timestamped = message.ShouldBeAssignableTo<IAisTimestamp>();
        timestamped.Timestamp.ShouldBe(ReceivedAt);
    }

    [TestMethod]
    public void TimestampParticipatesInRecordEquality()
    {
        AisMessageType27 first = CreateType27(ReceivedAt);
        AisMessageType27 sameTime = CreateType27(ReceivedAt);
        AisMessageType27 laterTime = CreateType27(ReceivedAt.AddSeconds(1));
        AisMessageType27 noTime = CreateType27();

        first.ShouldBe(sameTime);
        first.ShouldNotBe(laterTime);
        first.ShouldNotBe(noTime);
    }

    [TestMethod]
    public void TimestampSurvivesWithExpression()
    {
        AisMessageType27 message = CreateType27(ReceivedAt);

        AisMessageType27 copy = message with { RepeatIndicator = 1 };

        copy.Timestamp.ShouldBe(ReceivedAt);
    }

    private static AisMessageType27 CreateType27(DateTimeOffset? timestamp = null) =>
        new(
            CourseOverGround: 90.0f,
            GnssPositionStatus: false,
            Mmsi: 123456789,
            NavigationStatus: NavigationStatus.UnderwayUsingEngine,
            Position: new Position(1.0, 2.0),
            PositionAccuracy: true,
            RaimFlag: false,
            RepeatIndicator: 0,
            SpeedOverGround: 10.0f)
        {
            Timestamp = timestamp,
        };
}
