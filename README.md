# SignalForge

[![Build](https://github.com/Bodden007/SignalForge/actions/workflows/build.yml/badge.svg)](https://github.com/Bodden007/SignalForge/actions/workflows/build.yml)

**Industrial Protocol Gateway**

SignalForge is a .NET 10 / C# gateway for capturing, decoding, normalizing and publishing industrial protocol data.

The project is intentionally vendor-neutral. The first protocol module targets captured IEEE 802.3 LLC traffic, while the runtime and output architecture is designed to allow additional industrial protocols later.

## Current pipeline

```text
Mirrored Ethernet traffic
        |
        v
Packet Source
        |
        v
LLC Parser
        |
        v
Telemetry Decoder
        |
        v
Telemetry Store
        |
        v
NModbus TCP Server
        |
        v
OPC gateway / client
```

## Project structure

```text
Capture/     Packet acquisition boundary
Protocol/    Protocol parsing and decoding
Runtime/     Processing pipeline and current telemetry state
Modbus/      NModbus TCP output
Program.cs   Composition root
```

## Status

Early architecture skeleton.

Implemented:
- .NET 10 project
- NModbus 3.0.83 dependency
- vendor-neutral runtime skeleton
- initial LLC packet parser boundary
- telemetry snapshot/store
- Modbus TCP server output

Next:
- SharpPcap/Npcap packet source
- real LLC frame extraction
- reverse-engineered telemetry field decoding
- diagnostics and configuration

## Design principles

- SOLID where it solves an actual boundary
- no layers for the sake of layers
- protocol-specific knowledge stays inside protocol decoding
- normalized telemetry does not depend on transport or output protocol
- output adapters do not know how source packets were captured
