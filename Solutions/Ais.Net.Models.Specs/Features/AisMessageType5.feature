Feature: Static and Voyage Related Data

Background:
    Given I have an AIS message

Scenario Outline: Decoding static and voyage related data
    Given a new AisMessageType5 record with the following properties:
      | AisVersion | CallSign | Destination | DimensionToBow | DimensionToPort | DimensionToStarboard | DimensionToStern | Draught10thMetres | EtaDay | EtaHour | EtaMinute | EtaMonth | IsDteNotReady | ImoNumber | Mmsi  | PositionFixType | RepeatIndicator | ShipType | Spare423 | VesselName |
      | <ais_version> | <call_sign> | <destination> | <dim_bow> | <dim_port> | <dim_starboard> | <dim_stern> | <draught> | <eta_day> | <eta_hour> | <eta_min> | <eta_month> | <dte_not_ready> | <imo> | <mmsi> | <pos_fix> | <repeat> | <ship_type> | <spare> | <vessel_name> |
    When the AisMessageType5 is created
    Then the AisMessageType5 properties should be set correctly

    Examples:
      | ais_version | call_sign | destination | dim_bow | dim_port | dim_starboard | dim_stern | draught | eta_day | eta_hour | eta_min | eta_month | dte_not_ready | imo | mmsi  | pos_fix | repeat | ship_type | spare | vessel_name |
      | 1           | CALL      | DEST        | 1       | 2        | 3             | 4         | 5       | 6       | 7        | 8       | 9         | true          | 123 | 12345 | Gps     | 3      | 60        | 1     | VESSEL      |