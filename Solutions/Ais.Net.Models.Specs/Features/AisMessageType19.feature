Feature: AisMessageType19

Scenario: Create AisMessageType19 record
    Given a new AisMessageType19 record with the following properties:
      | CourseOverGround | DimensionToBow | DimensionToPort | DimensionToStarboard | DimensionToStern | IsAssigned | IsDteNotReady | Mmsi  | Position_Latitude | Position_Longitude | PositionAccuracy | PositionFixType | RaimFlag | RegionalReserved139 | RegionalReserved38 | RepeatIndicator | ShipName | ShipType | Spare308 | SpeedOverGround | TimeStampSecond | TrueHeadingDegrees |
      | 123.45           | 1              | 2               | 3                    | 4                | true       | true          | 12345 | 1                 | 2                  | true             | Gps             | true     | 1                   | 2                  | 3               | SHIP     | 60       | 1        | 12.34           | 56              | 78                 |
    When the AisMessageType19 is created
    Then the AisMessageType19 properties should be set correctly