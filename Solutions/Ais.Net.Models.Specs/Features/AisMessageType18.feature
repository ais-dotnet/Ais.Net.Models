Feature: AisMessageType18

Scenario: Create AisMessageType18 record
    Given a new AisMessageType18 record with the following properties:
      | CanAcceptMessage22ChannelAssignment | CanSwitchBands | CourseOverGroundDegrees | CsUnit | HasDisplay | IsAssigned | IsDscAttached | Mmsi  | Position_Latitude | Position_Longitude | PositionAccuracy | RadioStatusType | RaimFlag | RegionalReserved139 | RegionalReserved38 | RepeatIndicator | SpeedOverGround | TimeStampSecond | TrueHeadingDegrees |
      | true                                | true           | 123.45                  | Cstdma | true       | true       | true          | 12345 | 1                 | 2                  | true             | Itdma           | true     | 1                   | 2                  | 3               | 12.34           | 56              | 78                 |
    When the AisMessageType is created
    Then the properties should be set correctly