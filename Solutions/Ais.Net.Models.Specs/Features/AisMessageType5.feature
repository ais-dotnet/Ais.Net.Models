Feature: AisMessageType5

Scenario: Create AisMessageType5 record
    Given a new AisMessageType5 record with the following properties:
      | AisVersion | CallSign | Destination | DimensionToBow | DimensionToPort | DimensionToStarboard | DimensionToStern | Draught10thMetres | EtaDay | EtaHour | EtaMinute | EtaMonth | IsDteNotReady | ImoNumber | Mmsi  | PositionFixType | RepeatIndicator | ShipType | Spare423 | VesselName |
      | 1          | CALL     | DEST        | 1              | 2               | 3                    | 4                | 5                 | 6      | 7       | 8         | 9        | true          | 123       | 12345 | Gps             | 3               | 60       | 1        | VESSEL     |
    When the AisMessageType5 is created
    Then the AisMessageType5 properties should be set correctly