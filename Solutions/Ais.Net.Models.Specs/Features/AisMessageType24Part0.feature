Feature: Static Data Report Part A

Background:
    Given I have an AIS message

Scenario Outline: Decoding a Static Data Report Part A
    Given a new AisMessageType24Part0 record with the following properties:
      | Mmsi  | PartNumber | RepeatIndicator | Spare160 |
      | <mmsi> | <part_no> | <repeat> | <spare> |
    When the AisMessageType24Part0 is created
    Then the AisMessageType24Part0 properties should be set correctly

    Examples:
      | mmsi  | part_no | repeat | spare |
      | 12345 | 0       | 3      | 1     |