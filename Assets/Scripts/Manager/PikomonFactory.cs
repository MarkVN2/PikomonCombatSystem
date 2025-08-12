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

    private static readonly string[] RandomNames =
    {
        "Blaze", "Aqua", "Storm", "Boulder", "Spark", "Frost", "Viper", "Thunder",
        "Shadow", "Crimson", "Azure", "Ember", "Tsunami", "Cyclone", "Granite"
    };

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

        if (!string.IsNullOrEmpty(customName) && controller.GetPikomon() != null)
        {
            controller.GetPikomon().Name = customName;
        }
        else if (controller.GetPikomon() != null)
        {
            var randomName = RandomNames[Random.Range(0, RandomNames.Length)];
            controller.GetPikomon().Name = randomName;
        }

        UpdatePikomonVisuals(instance, controller, isCPU);
        instance.name = $"{pikomonType}_{controller.UniqueId}";

        return controller;
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