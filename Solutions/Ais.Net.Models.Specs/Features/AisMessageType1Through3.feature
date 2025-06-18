Feature: Class A Vessel Position Report

Background:
    Given I have an AIS message

Scenario Outline: Decoding a Class A vessel position report
    Given a new AisMessageType1Through3 record with the following properties:
        | CourseOverGround | ManoeuvreIndicator | MessageType | Mmsi  | NavigationStatus    | Position_Latitude | Position_Longitude | PositionAccuracy | RadioSlotTimeout | RadioSubMessage | RadioSyncState | RateOfTurn | RaimFlag | RepeatIndicator | SpareBits145 | SpeedOverGround | TimeStampSecond | TrueHeadingDegrees |
        | <course>         | <manoeuvre>        | 1           | <mmsi>| <nav_status>        | <lat>             | <long>             | <pos_accuracy>   | 1                | 2               | UtcDirect      | 1          | true     | 3               | 4            | <speed>         | 56              | 78                 |
    When the AisMessageType1Through3 is created
    Then the AisMessageType1Through3 properties should be set correctly

    Examples:
        | course | manoeuvre    | mmsi  | nav_status          | lat | long | pos_accuracy | speed |
        | 123.45 | NotAvailable | 12345 | UnderwayUsingEngine | 1.0 | 2.0  | true         | 12.34 |
        | 234.56 | NotAvailable | 54321 | AtAnchor            | 3.0 | 4.0  | true         | 0.0   |