Feature: Static Data Report Part B

Background:
    Given I have an AIS message

Scenario Outline: Decoding a Static Data Report Part B
    Given a new AisMessageType24Part1 record with the following properties:
      | CallSign | DimensionToBow | DimensionToPort | DimensionToStarboard | DimensionToStern | Mmsi  | MothershipMmsi | PartNumber | RepeatIndicator | SerialNumber | Spare162 | ShipType | UnitModelCode | VendorIdRev3 | VendorIdRev4 |
      | <call_sign> | <dim_bow> | <dim_port> | <dim_starboard> | <dim_stern> | <mmsi> | <mothership_mmsi> | <part_no> | <repeat> | <serial_no> | <spare> | <ship_type> | <unit_model> | <vendor_rev3> | <vendor_rev4> |
    When the AisMessageType24Part1 is created
    Then the AisMessageType24Part1 properties should be set correctly

    Examples:
      | call_sign | dim_bow | dim_port | dim_starboard | dim_stern | mmsi  | mothership_mmsi | part_no | repeat | serial_no | spare | ship_type | unit_model | vendor_rev3 | vendor_rev4 |
      | CALL      | 1       | 2        | 3             | 4         | 12345 | 54321           | 1       | 3      | 123       | 1     | 60        | 1          | VEN         | DOR         |