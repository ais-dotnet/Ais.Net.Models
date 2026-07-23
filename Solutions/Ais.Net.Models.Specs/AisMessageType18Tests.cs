namespace Ais.Net.Models.Specs;

using Ais.Net.Models;
using Ais.Net.Models.Abstractions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shouldly;

[TestClass]
public class AisMessageType18Tests
{
    [TestMethod]
    public void ClassBCsPositionReportExposesSuppliedValues()
    {
        AisMessageType18 message = new(
            CanAcceptMessage22ChannelAssignment: true,
            CanSwitchBands: true,
            CourseOverGround: 123.45f,
            CsUnit: ClassBUnit.Cstdma,
            HasDisplay: true,
            IsAssigned: true,
            IsDscAttached: true,
            Mmsi: 12345,
            Position: new Position(1.0, 2.0),
            PositionAccuracy: true,
            RadioStatusType: ClassBRadioStatusType.Itdma,
            RaimFlag: true,
            RegionalReserved139: 1,
            RegionalReserved38: 2,
            RepeatIndicator: 3,
            SpeedOverGround: 12.34f,
            TimeStampSecond: 56,
            TrueHeadingDegrees: 78);

        message.MessageType.ShouldBe(18);
        message.CanAcceptMessage22ChannelAssignment.ShouldBe(true);
        message.CanSwitchBands.ShouldBe(true);
        message.CourseOverGround.ShouldBe(123.45f);
        message.CsUnit.ShouldBe(ClassBUnit.Cstdma);
        message.HasDisplay.ShouldBe(true);
        message.IsAssigned.ShouldBe(true);
        message.IsDscAttached.ShouldBe(true);
        message.Mmsi.ShouldBe(12345u);
        message.Position.ShouldBe(new Position(1.0, 2.0));
        message.PositionAccuracy.ShouldBe(true);
        message.RadioStatusType.ShouldBe(ClassBRadioStatusType.Itdma);
        message.RaimFlag.ShouldBe(true);
        message.RegionalReserved139.ShouldBe(1);
        message.RegionalReserved38.ShouldBe(2);
        message.RepeatIndicator.ShouldBe(3u);
        message.SpeedOverGround.ShouldBe(12.34f);
        message.TimeStampSecond.ShouldBe(56u);
        message.TrueHeadingDegrees.ShouldBe(78u);
    }
}
