# GTA-Events Documentation

## Ped Events
| Event | Arguments | Description |
|---|---|---|
| `NearbyPedKilled` | `Ped, Entity killer` | A nearby ped was killed |
| `NearbyPedEnteredVehicle` | `Ped, Vehicle` | A nearby ped entered a vehicle |
| `NearbyPedLeftVehicle` | `Ped, Vehicle` | A nearby ped left a vehicle |
| `NearbyPedFleeing` | `Ped` | A nearby ped started fleeing |
| `NearbyPedStartedCombat` | `Ped, Entity target` | A nearby ped entered combat |
| `NearbyPedStoppedCombat` | `Ped` | A nearby ped left combat |

## Player Events
| Event | Arguments | Description |
|---|---|---|
| `PlayerEnteredVehicle` | `Vehicle` | Player entered a vehicle |
| `PlayerLeftVehicle` | `Vehicle` | Player left a vehicle |
| `PlayerDied` | `Entity killer` | Player died |
| `PlayerRevived` | — | Player was revived after dying |
| `PlayerWantedLevelChanged` | `int level` | Players wanted level changed |
| `PlayerWeaponChanged` | `Weapon, WeaponHash` | Players current weapon changed |
| `PlayerVehicleDamaged` | `Vehicle` | Players current vehicle took damage |
| `PlayerTookDamage` | `int damage` | Player took damage |

## World Events
| Event | Arguments | Description |
|---|---|---|
| `NearbyVehicleDestroyed` | `Vehicle` | A nearby vehicle was destroyed |
| `NearbyExplosion` | — | An explosion occurred nearby |

## Configuration
All events support these properties where relevant:

| Property | Type | Default | Description |
|---|---|---|---|
| `Radius` | `float` | `30f` | Detection radius around position |
| `Position` | `Vector3?` | `null` | Custom position, uses player position if null |

`NearbyExplosion` also supports:

| Property | Type | Default | Description |
|---|---|---|---|
| `Type` | `ExplosionType?` | `null` | Filter by explosion type, any type if null |
