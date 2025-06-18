Feature: AisMessageType24Part0

Scenario: Create AisMessageType24Part0 record
    Given a new AisMessageType24Part0 record with the following properties:
      | Mmsi  | PartNumber | RepeatIndicator | Spare160 |
      | 12345 | 0          | 3               | 1        |
    When the AisMessageType24Part0 is created
    Then the AisMessageType24Part0 properties should be set correctly