# Ais.Net.Models

Ais.Net.Models provides a series of [C# 9.0 records](https://devblogs.microsoft.com/dotnet/c-9-0-on-the-record/) which define the the message types, a series of interfaces that define common behaviours, and extension methods to help with type conversions & calculations.

| Package                                                         | Status                                                                                                    |
|-----------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------|
| [Ais.Net.Models](https://github.com/ais-dotnet/Ais.Net.Models/) | [![#](https://img.shields.io/nuget/v/Ais.Net.Models.svg)](https://www.nuget.org/packages/Ais.Net.Models/) |

The [AIS.NET](https://github.com/ais-dotnet/) project contains a series of layers, from a [low-level high performance NMEA AIS sentence decoder](https://github.com/ais-dotnet/Ais.Net/), to a [rich high-level C# 9.0 models](https://github.com/ais-dotnet/Ais.Net.Models/) of AIS message types, a [receiver component](https://github.com/ais-dotnet/Ais.Net.Receiver/) that can listen to TCP streams of NMEA sentences and expose them as an `IObservable<string>` of raw sentences or an decoded `IObservable<IAisMessage>`, and finally a Storage Client implementation to persisting the raw NMEA sentence stream to Azure Blob storage for future processing.

![https://github.com/ais-dotnet](https://endjincdn.blob.core.windows.net/assets/ais-dotnet-project-layers.png)

The table below shows the messages, their properties and how they are mapped to interfaces.

<details><summary><b>Show AIS Message Types and .NET Interfaces</b></summary>

|                         | Message Type 1 to 3  | Message Type 5       | Message Type 18                     | Message Type 19      | Message Type 24 Part 0 | Message Type 24 Part 1 | Message Type 27         |
|-------------------------|----------------------|----------------------|-------------------------------------|----------------------|------------------------|------------------------|-------------------------|
| IAisMessageType5        |                      | AisVersion           |                                     |                      |                        |                        |                         |
| ICallSign               |                      | CallSign             |                                     |                      |                        | CallSign               |                         |
| IAisMessageType18       |                      |                      | CanAcceptMessage22ChannelAssignment |                      |                        |                        |                         |
| IAisMessageType18       |                      |                      | CanSwitchBands                      |                      |                        |                        |                         |
| IVesselCourseOverGround | CourseOverGround     |                      | CourseOverGround                    | CourseOverGround     |                        |                        | CourseOverGround        |
| IAisMessageType18       |                      |                      | CsUnit                              |                      |                        |                        |                         |
| IAisMessageType5        |                      | Destination          |                                     |                      |                        |                        |                         |
| IVesselDimensions       |                      | DimensionToBow       |                                     | DimensionToBow       |                        | DimensionToBow         |                         |
| IVesselDimensions       |                      | DimensionToPort      |                                     | DimensionToPort      |                        | DimensionToPort        |                         |
| IVesselDimensions       |                      | DimensionToStarboard |                                     | DimensionToStarboard |                        | DimensionToStarboard   |                         |
| IVesselDimensions       |                      | DimensionToStern     |                                     | DimensionToStern     |                        | DimensionToStern       |                         |
| IAisMessageType5        |                      | Draught10thMetres    |                                     |                      |                        |                        |                         |
| IAisMessageType5        |                      | EtaMonth             |                                     |                      |                        |                        |                         |
| IAisMessageType5        |                      | EtaDay               |                                     |                      |                        |                        |                         |
| IAisMessageType5        |                      | EtaHour              |                                     |                      |                        |                        |                         |
| IAisMessageType5        |                      | EtaMinute            |                                     |                      |                        |                        |                         |
| IAisMessageType18       |                      |                      | HasDisplay                          |                      |                        |                        |                         |
| IIsAssigned             |                      |                      | IsAssigned                          | IsAssigned           |                        |                        |                         |
| IAisMessageType18       |                      |                      | IsDscAttached                       |                      |                        |                        |                         |
| IAisMessageType5        |                      | ImoNumber            |                                     |                      |                        |                        |                         |
| IAisIsDteNotReady       |                      | IsDteNotReady        |                                     | IsDteNotReady        |                        |                        |                         |
| IVesselNavigation       | Latitude10000thMins  |                      | Latitude10000thMins                 | Latitude10000thMins  |                        |                        |                         |
| IVesselNavigation       | Longitude10000thMins |                      | Longitude10000thMins                | Longitude10000thMins |                        |                        |                         |
| IAisMessageType1to3     | ManoeuvreIndicator   |                      |                                     |                      |                        |                        |                         |
| IAisMessageType24Part1  |                      |                      |                                     |                      |                        | MothershipMmsi         |                         |
| IAisMessageType         | MessageType          | MessageType          | MessageType                         | MessageType          | MessageType            | MessageType            |                         |
| IVesselIdentity         | Mmsi                 | Mmsi                 | Mmsi                                | Mmsi                 | Mmsi                   | Mmsi                   |                         |
| IAisMultipartMessage    |                      |                      |                                     |                      | PartNumber             | PartNumber             |                         |
| IVesselPositionAccuracy | PositionAccuracy     |                      | PositionAccuracy                    | PositionAccuracy     |                        |                        | PositionAccuracy        |
| IAisPositionFixType     |                      | PositionFixType      |                                     | PositionFixType      |                        |                        |                         |
| IAisMessageType18       |                      |                      | RadioStatusType                     |                      |                        |                        |                         |
| IAisMessageType1to3     | RadioSlotTimeout     |                      |                                     |                      |                        |                        |                         |
| IAisMessageType1to3     | RadioSubMessage      |                      |                                     |                      |                        |                        |                         |
| IAisMessageType1to3     | RadioSyncState       |                      |                                     |                      |                        |                        |                         |
| IAisMessageType19       |                      |                      |                                     | RegionalReserved139  |                        |                        |                         |
| IAisMessageType19       |                      |                      |                                     | RegionalReserved38   |                        |                        |                         |
| IRaimFlag               | RaimFlag             |                      | RaimFlag                            | RaimFlag             |                        |                        | RaimFlag                |
| IAisMessageType18       |                      |                      | RegionalReserved139                 |                      |                        |                        |                         |
| IAisMessageType18       |                      |                      | RegionalReserved38                  |                      |                        |                        |                         |
| IAisMessageType1to3     | RateOfTurn           |                      |                                     |                      |                        |                        |                         |
| IRepeatIndicator        | RepeatIndicator      | RepeatIndicator      | RepeatIndicator                     | RepeatIndicator      | RepeatIndicator        | RepeatIndicator        | RepeatIndicator         |
| IAisMessageType24Part1  |                      |                      |                                     |                      |                        | SerialNumber           |                         |
| IAisMessageType19       |                      |                      |                                     | ShipName             |                        |                        |                         |
| IShipType               |                      | ShipType             |                                     | ShipType             |                        | ShipType               |                         |
| IAisMessageType1to3     | SpareBits145         |                      |                                     |                      |                        |                        |                         |
| IAisMessageType24Part0  |                      |                      |                                     |                      | Spare160               |                        |                         |
| IAisMessageType24Part1  |                      |                      |                                     |                      |                        | Spare162               |                         |
| IAisMessageType5        |                      | Spare423             |                                     |                      |                        |                        |                         |
| IAisMessageType19       |                      |                      |                                     | Spare308             |                        |                        |                         |
| IVesselSpeedOverGround  | SpeedOverGround      |                      | SpeedOverGround                     | SpeedOverGround      |                        |                        | SpeedOverGround         |
| IVesselNavigation       | TimeStampSecond      |                      | TimeStampSecond                     | TimeStampSecond      |                        |                        |                         |
| IVesselNavigation       | TrueHeadingDegrees   |                      | TrueHeadingDegrees                  | TrueHeadingDegrees   |                        |                        |                         |
| IAisMessageType24Part1  |                      |                      |                                     |                      |                        | UnitModelCode          |                         |
| IAisMessageType24Part1  |                      |                      |                                     |                      |                        | VendorIdRev3           |                         |
| IAisMessageType24Part1  |                      |                      |                                     |                      |                        | VendorIdRev4           |                         |
| IVesselName             |                      | VesselName           |                                     |                      |                        |                        |                         |
| IAisMessageType27       |                      |                      |                                     |                      |                        |                        | GnssPositionStatus      |
| IAisMessageType27       |                      |                      |                                     |                      |                        |                        | Position                |
| IVesselNavigationStatus | NavigationStatus     |                      |                                     |                      |                        |                        | NavigationStatus        |
</details>

The C# record types then implement the relevant interfaces, which enables simpler higher level programming constructs, such as Rx queries over an `IAisMessage` stream:

```csharp
IObservable<IGroupedObservable<uint, IAisMessage>> byVessel = receiverHost.Messages.GroupBy(m => m.Mmsi);

IObservable<(uint mmsi, IVesselNavigation navigation, IVesselName name)>? vesselNavigationWithNameStream =
    from perVesselMessages in byVessel
    let vesselNavigationUpdates = perVesselMessages.OfType<IVesselNavigation>()
    let vesselNames = perVesselMessages.OfType<IVesselName>()
    let vesselLocationsWithNames = vesselNavigationUpdates.CombineLatest(vesselNames, (navigation, name) => (navigation, name))
    from vesselLocationAndName in vesselLocationsWithNames
    select (mmsi: perVesselMessages.Key, vesselLocationAndName.navigation, vesselLocationAndName.name);
```

## Licenses

This project is available under the Apache 2.0 open source license.

[![GitHub license](https://img.shields.io/badge/License-Apache%202-blue.svg)](https://raw.githubusercontent.com/ais-dotnet/Ais.Net.Models/main/LICENSE)

For any licensing questions, please email [&#108;&#105;&#99;&#101;&#110;&#115;&#105;&#110;&#103;&#64;&#101;&#110;&#100;&#106;&#105;&#110;&#46;&#99;&#111;&#109;](&#109;&#97;&#105;&#108;&#116;&#111;&#58;&#108;&#105;&#99;&#101;&#110;&#115;&#105;&#110;&#103;&#64;&#101;&#110;&#100;&#106;&#105;&#110;&#46;&#99;&#111;&#109;)

## Project Sponsor

This project is sponsored by [endjin](https://endjin.com), a UK based Technology Consultancy which specializes in Data & Analytics, AI & Cloud Native App Dev, and is a [.NET Foundation Corporate Sponsor](https://dotnetfoundation.org/membership/corporate-sponsorship).

> We help small teams achieve big things.

We produce two free weekly newsletters: 

 - [Azure Weekly](https://azureweekly.info) for all things about the Microsoft Azure Platform
 - [Power BI Weekly](https://powerbiweekly.info) for all things Power BI, Microsoft Fabric, and Azure Synapse Analytics

Keep up with everything that's going on at endjin via our [blog](https://endjin.com/blog), follow us on [Twitter](https://twitter.com/endjin), [YouTube](https://www.youtube.com/c/endjin) or [LinkedIn](https://www.linkedin.com/company/endjin).

We have become the maintainers of a number of popular .NET Open Source Projects:

- [Reactive Extensions for .NET](https://github.com/dotnet/reactive)
- [Reaqtor](https://github.com/reaqtive)
- [Argotic Syndication Framework](https://github.com/argotic-syndication-framework/)

And we have over 50 Open Source projects of our own, spread across the following GitHub Orgs:

- [endjin](https://github.com/endjin/)
- [Corvus](https://github.com/corvus-dotnet)
- [Menes](https://github.com/menes-dotnet)
- [Marain](https://github.com/marain-dotnet)
- [AIS.NET](https://github.com/ais-dotnet)

And the DevOps tooling we have created for managing all these projects is available on the [PowerShell Gallery](https://www.powershellgallery.com/profiles/endjin).

For more information about our products and services, or for commercial support of this project, please [contact us](https://endjin.com/contact-us). 

## Code of conduct

This project has adopted a code of conduct adapted from the [Contributor Covenant](http://contributor-covenant.org/) to clarify expected behaviour in our community. This code of conduct has been [adopted by many other projects](http://contributor-covenant.org/adopters/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;](&#109;&#097;&#105;&#108;&#116;&#111;:&#104;&#101;&#108;&#108;&#111;&#064;&#101;&#110;&#100;&#106;&#105;&#110;&#046;&#099;&#111;&#109;) with any additional questions or comments.

## IP Maturity Model (IMM)

The [IP Maturity Model](https://github.com/endjin/Endjin.Ip.Maturity.Matrix) is endjin's IP quality assessment framework, which we've developed over a number of years when doing due diligence assessments of 3rd party systems. We've codified the approach into a [configurable set of rules](https://github.com/endjin/Endjin.Ip.Maturity.Matrix.RuleDefinitions), which are committed into the [root of a repo](imm.yaml), and a [Azure Function HttpTrigger](https://github.com/endjin/Endjin.Ip.Maturity.Matrix/tree/main/Solutions/Endjin.Ip.Maturity.Matrix.Host) HTTP endpoint which can evaluate the ruleset, and render an svg badge for display in repo's `readme.md`.

## IP Maturity Model Scores

[![Shared Engineering Standards](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/74e29f9b-6dca-4161-8fdd-b468a1eb185d?nocache=true)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/74e29f9b-6dca-4161-8fdd-b468a1eb185d?cache=false)

[![Coding Standards](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/f6f6490f-9493-4dc3-a674-15584fa951d8?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/f6f6490f-9493-4dc3-a674-15584fa951d8?cache=false)

[![Executable Specifications](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/bb49fb94-6ab5-40c3-a6da-dfd2e9bc4b00?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/bb49fb94-6ab5-40c3-a6da-dfd2e9bc4b00?cache=false)

[![Code Coverage](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/0449cadc-0078-4094-b019-520d75cc6cbb?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/0449cadc-0078-4094-b019-520d75cc6cbb?cache=false)

[![Benchmarks](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/64ed80dc-d354-45a9-9a56-c32437306afa?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/64ed80dc-d354-45a9-9a56-c32437306afa?cache=false)

[![Reference Documentation](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/2a7fc206-d578-41b0-85f6-a28b6b0fec5f?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/2a7fc206-d578-41b0-85f6-a28b6b0fec5f?cache=false)

[![Design & Implementation Documentation](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/f026d5a2-ce1a-4e04-af15-5a35792b164b?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/f026d5a2-ce1a-4e04-af15-5a35792b164b?cache=false)

[![How-to Documentation](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/145f2e3d-bb05-4ced-989b-7fb218fc6705?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/145f2e3d-bb05-4ced-989b-7fb218fc6705?cache=false)

[![Date of Last IP Review](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/da4ed776-0365-4d8a-a297-c4e91a14d646?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/da4ed776-0365-4d8a-a297-c4e91a14d646?cache=false)

[![Framework Version](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/6c0402b3-f0e3-4bd7-83fe-04bb6dca7924?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/6c0402b3-f0e3-4bd7-83fe-04bb6dca7924?cache=false)

[![Associated Work Items](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/79b8ff50-7378-4f29-b07c-bcd80746bfd4?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/79b8ff50-7378-4f29-b07c-bcd80746bfd4?cache=false)

[![Source Code Availability](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/30e1b40b-b27d-4631-b38d-3172426593ca?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/30e1b40b-b27d-4631-b38d-3172426593ca?cache=false)

[![License](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/d96b5bdc-62c7-47b6-bcc4-de31127c08b7?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/d96b5bdc-62c7-47b6-bcc4-de31127c08b7?cache=false)

[![Production Use](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/87ee2c3e-b17a-4939-b969-2c9c034d05d7?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/87ee2c3e-b17a-4939-b969-2c9c034d05d7?cache=false)

[![Insights](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/71a02488-2dc9-4d25-94fa-8c2346169f8b?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/71a02488-2dc9-4d25-94fa-8c2346169f8b?cache=false)

[![Packaging](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/547fd9f5-9caf-449f-82d9-4fba9e7ce13a?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/547fd9f5-9caf-449f-82d9-4fba9e7ce13a?cache=false)

[![Deployment](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/edea4593-d2dd-485b-bc1b-aaaf18f098f9?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/edea4593-d2dd-485b-bc1b-aaaf18f098f9?cache=false)

[![OpenChain](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/66efac1a-662c-40cf-b4ec-8b34c29e9fd7?cache=false)](https://imm.endjin.com/api/imm/github/ais-dotnet/Ais.Net.Models/rule/66efac1a-662c-40cf-b4ec-8b34c29e9fd7?cache=false)