![](https://github.com/umbrix-dev/GTA-Events/blob/master/BANNER.png)

![Version](https://img.shields.io/github/v/tag/umbrix-dev/GTA-Events?label=version)
![License](https://img.shields.io/github/license/umbrix-dev/GTA-Events)
![SHVDN3](https://img.shields.io/badge/ScriptHookVDotNet-3.x-blue)
![Events](https://img.shields.io/badge/Events-25%2B-brightgreen)

A comprehensive and easy to use event system for SHVDN3.

> [!NOTE]
> GTA-Events is also only working on the legacy version of GTA V and does not support SHVDN2.

---

## Installation
1. Install [ScriptHookVDotNet3](https://github.com/scripthookvdotnet/scripthookvdotnet)
2. Get the latest or preferred `GTA-Events-vX.dll` from the [releases](https://github.com/umbrix-dev/GTA-Events/releases) page
3. Put the downloaded file into your `Grand Theft Auto V Legacy\scripts` directory
4. For developing just add the reference to the `.dll` file

## Usage
```csharp
using GTA.Events;

Events.NearbyPedKilled.Connect += (ped, killer) => { };
Events.PlayerEnteredVehicle.Connect += (vehicle) => { };
Events.PlayerLeftVehicle.Connect += (vehicle) => { };
Events.NearbyExplosion.Connect += () => { };
Events.PlayerDied.Connect += (killer) => { };
```

## Configuration
```csharp
Events.NearbyPedKilled.Radius = 50f;
Events.NearbyExplosion.Type = ExplosionType.Grenade;
Events.NearbyExplosion.Position = new Vector3(100f, 200f, 30f);
```

## Available Events
The project currently includes 25+ events, including
- Combat events
- Player state events
- Vehicle interaction events
- Explosion detection
- Proximity-based triggers
- Death tracking

Full documentation: **[DOCS.MD](https://github.com/umbrix-dev/GTA-Events/blob/master/DOCS.md)**

## Contributing
Contributions, suggestions, and event requests are welcome.

If you need a specific hook or have problems with one, open an issue.

## License
MIT
