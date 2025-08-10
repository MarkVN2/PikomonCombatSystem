# Pikomon System Usage Guide

## Overview

The Pikomon system supports both asset-based and runtime-based creation of Pikomons, giving you flexibility for different use cases.

## Two Ways to Use Pikomons

### Method 1: ScriptableObject Assets (For Persistent/Reusable Pikomons)

Perfect for creating Pikomons that you want to reuse or configure in the editor.

#### Creating Pikomon Assets

1. **Right-click in the Project window**
2. **Go to Create > Pikomon**
3. **Select the type you want:**
   - Base Pikomon
   - Himon (Fire-type)
   - Aquamon (Water-type)
4. **Name your asset** (e.g., "FireDragon_Himon", "SeaSerpent_Aquamon")
5. **Configure the properties** in the Inspector if needed

#### Using Assets in PikoController

1. **Select your GameObject** with the `PikoController` script
2. **In the Inspector**, find the Pikomon fields
3. **Drag any Pikomon ScriptableObject** from your Project window to the field

### Method 2: Runtime Creation (For Dynamic/Custom Pikomons)

Perfect for creating Pikomons on-the-fly with custom names like "Jorge".

#### Creating at Runtime

```csharp
// Create a Himon named "Jorge" at runtime
var jorge = Himon.CreateRuntimeHimon("Jorge");

// Create an Aquamon named "Splash" at runtime
var splash = Aquamon.CreateRuntimeAquamon("Splash");

// Generic method for any Pikomon type
var customPikomon = Pikomon.CreateRuntimePikomon<Himon>("CustomName");
```

#### Example Usage

The `PikoController` includes an example:

1. **Set the customHimonName** field in the Inspector (e.g., "Jorge")
2. **Right-click the PikoController** in the Inspector
3. **Select "Create Custom Himon"** from the context menu
4. A new Himon with your custom name will be created and assigned!

## Key Benefits

- **Flexible Creation**: Use assets for persistent Pikomons, runtime creation for dynamic ones
- **Polymorphic Assignment**: Assign any Pikomon type to any Pikomon field
- **No Asset Clutter**: Runtime creation doesn't create project files
- **Editor-Friendly**: Assets can be configured in the Inspector
- **Custom Names**: Easily create Pikomons with any name you want

### Adding New Pikomon Types

To create a new Pikomon type:

1. Create a new script that inherits from `Pikomon`
2. Add the `[CreateAssetMenu]` attribute
3. Implement initialization in `OnEnable()`
4. Set species-specific stats and powers

Example:

```csharp
[CreateAssetMenu(fileName = "New WindSpirit", menuName = "Pikomon/WindSpirit")]
public class WindSpirit : Pikomon
{
    private void OnEnable()
    {
        if (string.IsNullOrEmpty(Species))
        {
            InitializeWindSpirit();
        }
    }

    private void InitializeWindSpirit()
    {
        Name = "WindSpirit";
        Species = "WindSpirit";
        Element = new Wind();
        // Set other stats...
    }
}
```
