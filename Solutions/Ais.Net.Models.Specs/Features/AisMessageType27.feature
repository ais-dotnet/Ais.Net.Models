Feature: AisMessageType27

Scenario: Create AisMessageType27 record
    Given a new AisMessageType27 record with the following properties:
      | CourseOverGround | GnssPositionStatus | Mmsi  | NavigationStatus    | Position_Latitude | Position_Longitude | PositionAccuracy | RaimFlag | RepeatIndicator | SpeedOverGround |
      | 123.45           | true               | 12345 | UnderwayUsingEngine | 1                 | 2                  | true             | true     | 3               | 12.34           |
    When the AisMessageType27 is created
    Then the AisMessageType27 properties should be set correctly