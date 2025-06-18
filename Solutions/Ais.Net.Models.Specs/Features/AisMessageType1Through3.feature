Feature: AisMessageType1Through3

Scenario: Create AisMessageType1Through3 record
    Given a new AisMessageType1Through3 record with the following properties:
      | CourseOverGround | ManoeuvreIndicator | MessageType | Mmsi  | NavigationStatus | Position_Latitude | Position_Longitude | PositionAccuracy | RadioSlotTimeout | RadioSubMessage | RadioSyncState | RateOfTurn | RaimFlag | RepeatIndicator | SpareBits145 | SpeedOverGround | TimeStampSecond | TrueHeadingDegrees |
      | 123.45           | NotAvailable       | 1           | 12345 | UnderwayUsingEngine | 1                 | 2                  | true             | 1                | 2               | UtcDirect      | 1          | true     | 3               | 4            | 12.34           | 56              | 78                 |
    When the AisMessageType1Through3 is created
    Then the AisMessageType1Through3 properties should be set correctly