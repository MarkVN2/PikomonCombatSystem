using System.Collections.Generic;
using UnityEngine;

public static class PikomonFactory
{
    // I don't really think this is the ideal way to go with this.
    private static readonly Dictionary<string, string> PrefabPaths = new()
    {
        { "Himon", "Prefabs/Pikomons/Fire/Himon" },
        { "Aquamon", "Prefabs/Pikomons/Water/Aquamon" },
        { "Pikomonomon", "Prefabs/Pikomons/Fire/Pikomonomon" },
        { "Helmhon", "Prefabs/Pikomons/Fire/Helmhon" },
        { "Dysmon", "Prefabs/Pikomons/Wind/Dsymon" },
        { "Megitmon", "Prefabs/Pikomons/Wind/Megitmon" },
        { "Arvmon", "Prefabs/Pikomons/Earth/Arvmon" },
        { "Rokumon", "Prefabs/Pikomons/Earth/Rokumon" },
        { "Madoimon", "Prefabs/Pikomons/Earth/Madoimon" },
        { "Mekalomon", "Prefabs/Pikomons/Water/Mekalomon" }
    };

    // AI doing what it's good at, giving random things.
    private static readonly string[] RandomNames =
    {
    "Blaze", "Ember", "Inferno", "Flare", "Scorch", "Cinder", "Phoenix", "Pyre",

    "Aqua", "Tsunami", "Frost", "Glacier", "Torrent", "Cascade", "Neptune", "Tidal",
    "Ripple", "Mist", "Surge", "Arctic", "Crystal", "Marina", "Coral",

    "Boulder", "Granite", "Terra", "Ridge", "Canyon", "Summit", "Stone", "Cliff",
    "Forest", "Grove", "Moss", "Thorn", "Bramble", "Sage", "Willow",

    "Storm", "Cyclone", "Tempest", "Gale", "Breeze", "Zephyr", "Hurricane", "Whirlwind",
    "Nimbus", "Stratus", "Cumulus", "Vapor",

    "Spark", "Thunder", "Lightning", "Volt", "Charge", "Static", "Plasma", "Tesla",
    "Dynamo", "Current", "Flux",

    "Shadow", "Shade", "Dusk", "Midnight", "Eclipse", "Obsidian", "Raven", "Onyx",
    "Noir", "Umbra", "Phantom",

    "Crimson", "Azure", "Radiant", "Stellar", "Nova", "Comet", "Lunar", "Solar",
    "Prism", "Aurora", "Dawn", "Zenith",

    "Viper", "Serpent", "Drake", "Wyvern", "Chimera", "Sphinx", "Griffin", "Hydra",
    "Titan", "Golem", "Spirit", "Wraith",

    "Ruby", "Sapphire", "Emerald", "Diamond", "Topaz", "Quartz", "Opal", "Amber",
    "Jade", "Pearl", "Garnet",

    "Blade", "Spear", "Shield", "Arrow", "Sword", "Lance", "Axe", "Dagger",

    "Nexus", "Vortex", "Echo", "Pulse", "Rebel", "Rogue", "Hunter", "Ranger",
    "Scout", "Guardian", "Sentinel", "Warden", "Champion", "Valor", "Honor",
    "Fury", "Rage", "Chaos", "Order", "Balance", "Harmony", "Discord",
    "Venom", "Toxic", "Acid", "Poison", "Antidote", "Remedy"
    };
    private static string GetRandomName()
    {
        return RandomNames[Random.Range(0, RandomNames.Length)];
    }
    public static PikoController SpawnRandomPikomon(Vector3 position = default, bool isCPU = false)
    {
        var types = new List<string>(PrefabPaths.Keys);
        var randomType = types[Random.Range(0, types.Count)];
        return SpawnSpecificPikomon(randomType, position, null, isCPU);
    }

    public static PikoController SpawnSpecificPikomon(string pikomonType, Vector3 position = default, string customName = null, bool isCPU = false)
    {
        if (!PrefabPaths.TryGetValue(pikomonType, out string prefabPath))
        {
            Debug.LogError($"No prefab path found for {pikomonType}");
            return null;
        }

        GameObject prefab = Resources.Load<GameObject>(prefabPath);
        if (prefab == null)
        {
            Debug.LogError($"Could not load prefab at path: {prefabPath}");
            return null;
        }

        GameObject instance = Object.Instantiate(prefab, position, Quaternion.identity);
        PikoController controller = instance.GetComponent<PikoController>();

        if (controller == null)
        {
            Debug.LogError($"Prefab {pikomonType} does not have a PikoController component!");
            return null;
        }

        if (controller.GetPikomon() != null)
        {
            var originalPikomon = controller.GetPikomon();
            var runtimeCopy = CreateRuntimeCopy(originalPikomon, customName ?? GetRandomName());

            if (runtimeCopy != null)
            {
                controller.SetPikomon(runtimeCopy);
                Debug.Log($"Created runtime copy for {runtimeCopy.Name} with {runtimeCopy.Health}/{runtimeCopy.MaxHealth} health");
            }
        }

        UpdatePikomonVisuals(instance, controller, isCPU);
        instance.name = $"{pikomonType}_{controller.UniqueId}";

        return controller;
    }

    private static Pikomon CreateRuntimeCopy(Pikomon original, string customName)
    {
        Debug.Log($"Creating runtime copy with name: '{customName}' for type: {original.GetType().Name}");
        // ha-ha-ha-ha...not very maintenance friendly 
        return original.GetType().Name switch
        {
            nameof(Himon) => Pikomon.CreateRuntimePikomon<Himon>(customName),
            nameof(Aquamon) => Pikomon.CreateRuntimePikomon<Aquamon>(customName),
            nameof(Pikomonomon) => Pikomon.CreateRuntimePikomon<Pikomonomon>(customName),
            nameof(Helmhon) => Pikomon.CreateRuntimePikomon<Helmhon>(customName),
            nameof(Dysmon) => Pikomon.CreateRuntimePikomon<Dysmon>(customName),
            nameof(Megitmon) => Pikomon.CreateRuntimePikomon<Megitmon>(customName),
            nameof(Arvmon) => Pikomon.CreateRuntimePikomon<Arvmon>(customName),
            nameof(Rokumon) => Pikomon.CreateRuntimePikomon<Rokumon>(customName),
            nameof(Madoimon) => Pikomon.CreateRuntimePikomon<Madoimon>(customName),
            nameof(Mekalomon) => Pikomon.CreateRuntimePikomon<Mekalomon>(customName),
            _ => throw new System.ArgumentException($"Unknown Pikomon type: {original.GetType().Name}")
        };

    }

    private static void UpdatePikomonVisuals(GameObject instance, PikoController controller, bool isCPU)
    {
        var pikomon = controller.GetPikomon();
        if (pikomon != null)
        {
            var spriteRenderer = instance.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                if (isCPU && pikomon.FrontSprite != null)
                {
                    spriteRenderer.sprite = pikomon.FrontSprite;
                    Debug.Log($"CPU Pikomon using FrontSprite: {pikomon.Name}");
                }
                else if (!isCPU && pikomon.BackSprite != null)
                {
                    spriteRenderer.sprite = pikomon.BackSprite;
                    Debug.Log($"Player Pikomon using BackSprite: {pikomon.Name}");
                }
                else
                {
                    spriteRenderer.sprite = pikomon.FrontSprite ?? pikomon.BackSprite;
                    Debug.LogWarning($"Missing sprite for {pikomon.Name}, using fallback");
                }
            }
        }
    }
    public static PikoController SpawnPlayerPikomon(Vector3 position = default, string customName = null)
    {
        var types = new List<string>(PrefabPaths.Keys);
        var randomType = types[Random.Range(0, types.Count)];
        return SpawnSpecificPikomon(randomType, position, customName, false); // Player = back sprite
    }
    public static PikoController SpawnCPUPikomon(Vector3 position = default, string customName = null)
    {
        var types = new List<string>(PrefabPaths.Keys);
        var randomType = types[Random.Range(0, types.Count)];
        return SpawnSpecificPikomon(randomType, position, customName, true); // CPU = front sprite
    }

    public static (PikoController player, PikoController cpu) SpawnBattlePair(Vector3 playerPosition, Vector3 cpuPosition)
    {
        var playerController = SpawnPlayerPikomon(playerPosition);
        var cpuController = SpawnCPUPikomon(cpuPosition);

        return (playerController, cpuController);
    }

}