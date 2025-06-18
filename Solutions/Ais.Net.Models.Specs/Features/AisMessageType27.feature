Feature: Long-Range AIS Broadcast message

Background:
    Given I have an AIS message

Scenario Outline: Decoding a Long-Range AIS Broadcast message
    Given a new AisMessageType27 record with the following properties:
      | CourseOverGround | GnssPositionStatus | Mmsi  | NavigationStatus    | Position_Latitude | Position_Longitude | PositionAccuracy | RaimFlag | RepeatIndicator | SpeedOverGround |
      | <course>         | <gnss_status>      | <mmsi> | <nav_status>        | <lat>             | <long>             | <pos_accuracy>   | <raim>   | <repeat>        | <speed>         |
    When the AisMessageType27 is created
    Then the AisMessageType27 properties should be set correctly

    Examples:
      | course | gnss_status | mmsi  | nav_status          | lat | long | pos_accuracy | raim | repeat | speed |
      | 123.45 | true        | 12345 | UnderwayUsingEngine | 1.0 | 2.0  | true         | true | 3      | 12.34 |