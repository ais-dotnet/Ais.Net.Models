Feature: AisMessageType24Part1

Scenario: Create AisMessageType24Part1 record
    Given a new AisMessageType24Part1 record with the following properties:
      | CallSign | DimensionToBow | DimensionToPort | DimensionToStarboard | DimensionToStern | Mmsi  | MothershipMmsi | PartNumber | RepeatIndicator | SerialNumber | Spare162 | ShipType | UnitModelCode | VendorIdRev3 | VendorIdRev4 |
      | CALL     | 1              | 2               | 3                    | 4                | 12345 | 54321          | 1          | 3               | 123          | 1        | 60       | 1             | VEN          | DOR          |
    When the AisMessageType24Part1 is created
    Then the AisMessageType24Part1 properties should be set correctly