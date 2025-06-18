Feature: Class B "CS" Position Report

Background:
    Given I have an AIS message

Scenario Outline: Decoding a Class B "CS" position report
    Given a new AisMessageType18 record with the following properties:
      | CanAcceptMessage22ChannelAssignment | CanSwitchBands | CourseOverGroundDegrees | CsUnit | HasDisplay | IsAssigned | IsDscAttached | Mmsi  | Position_Latitude | Position_Longitude | PositionAccuracy | RadioStatusType | RaimFlag | RegionalReserved139 | RegionalReserved38 | RepeatIndicator | SpeedOverGround | TimeStampSecond | TrueHeadingDegrees |
      | <can_accept_msg22> | <can_switch_bands> | <course> | <cs_unit> | <has_display> | <is_assigned> | <is_dsc_attached> | <mmsi> | <lat> | <long> | <pos_accuracy> | <radio_status> | <raim> | <reg_res_139> | <reg_res_38> | <repeat> | <speed> | <timestamp> | <true_heading> |
    When the AisMessageType is created
    Then the properties should be set correctly

    Examples:
      | can_accept_msg22 | can_switch_bands | course | cs_unit | has_display | is_assigned | is_dsc_attached | mmsi  | lat | long | pos_accuracy | radio_status | raim | reg_res_139 | reg_res_38 | repeat | speed | timestamp | true_heading |
      | true             | true             | 123.45 | Cstdma  | true        | true        | true            | 12345 | 1.0 | 2.0  | true         | Itdma        | true | 1           | 2          | 3      | 12.34 | 56        | 78           |