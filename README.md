# Durability-Multipier

Durability Multiplier is a plugin for Oxide that allows rust server administrators & owners to adjust the durability of tools and weapons by applying a configurable multiplier.

##**Features**
1. Modify the durability of items when they are repaired.
2. Configurable multiplier to control durability adjustments.
3. Provides player feedback when the durability multiplier is applied.

##**Installation**
1. Download the `DurabilityMultiplier.cs` file.
2. Place the file in the `oxide/plugins` directory on your Rust server.
3. Restart your server or use the `oxide.reload DurabilityMultiplier` console command to load the plugin.

## **Configuration**
The plugin comes with a default configuration file that can be adjusted to your needs.

## **Default Configuration**
```json
{
  "Durability Multiplier": 2.0
}

## **Commands/Permissions**
This plugin does not have any player or admin commands; configuration is handled via the JSON configuration file.
No permissions are required for this plugin.

## **License**
This plugin is provided as-is. Modify and distribute freely under the terms of the MIT License.
