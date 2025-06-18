Feature: Class B "SO" Position Report

Background:
    Given I have an AIS message

Scenario Outline: Decoding a Class B "SO" position report
    Given a new AisMessageType19 record with the following properties:
      | CourseOverGround | DimensionToBow | DimensionToPort | DimensionToStarboard | DimensionToStern | IsAssigned | IsDteNotReady | Mmsi  | Position_Latitude | Position_Longitude | PositionAccuracy | PositionFixType | RaimFlag | RegionalReserved139 | RegionalReserved38 | RepeatIndicator | ShipName | ShipType | Spare308 | SpeedOverGround | TimeStampSecond | TrueHeadingDegrees |
      | <course>         | <dim_bow>      | <dim_port>      | <dim_starboard>      | <dim_stern>      | <is_assigned> | <dte_not_ready> | <mmsi> | <lat> | <long> | <pos_accuracy> | <pos_fix> | <raim> | <reg_res_139> | <reg_res_38> | <repeat> | <ship_name> | <ship_type> | <spare> | <speed> | <timestamp> | <true_heading> |
    When the AisMessageType19 is created
    Then the AisMessageType19 properties should be set correctly

    Examples:
      | course | dim_bow | dim_port | dim_starboard | dim_stern | is_assigned | dte_not_ready | mmsi  | lat | long | pos_accuracy | pos_fix | raim | reg_res_139 | reg_res_38 | repeat | ship_name | ship_type | spare | speed | timestamp | true_heading |
      | 123.45 | 1       | 2        | 3             | 4         | true        | true          | 12345 | 1.0 | 2.0  | true         | Gps     | true | 1           | 2          | 3      | SHIP      | 60        | 1     | 12.34 | 56        | 78           |