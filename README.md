# GTA-Events
A comprehensive event system for SHVDN3 - subscribe to GTA 5 events with a clean API.

&nbsp;
> [!WARNING]
> Requires [ScriptHookVDotNet3](https://github.com/scripthookvdotnet/scripthookvdotnet). SHVDN2 is not supported.

&nbsp;
> [!NOTE]
> This project is in early development. More events are being added actively — contributions and suggestions are welcome.

&nbsp;
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

| `PlayerDied` | `Entity killer` |

## Events
See all latest available events at: [DOCS.MD](https://github.com/umbrix-dev/GTA-Events/edit/master/DOCS.md)

## License
MIT
