using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public GameObject item;
    public float minY;
    public float maxY;
}

[System.Serializable]
public struct Entity
{
    public GameObject entity;
    public float spawnY;
}

[System.Serializable]
public struct Structure
{
    public GameObject structure;
    public float spawnY;
}

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField] private Transform genPoint;
    [SerializeField] private GameObject dirtObj;
    [SerializeField] private GameObject grassObj;
    [SerializeField] private float terrainWidth;
    [SerializeField] private float terrainHeight;
    [SerializeField] private Transform player;
    [SerializeField] private float playerYOffset;
    [SerializeField] private Item[] items;
    [SerializeField] private Entity[] entities;
    [SerializeField] private Structure[] structures;
    [SerializeField] private int itemSpawnRange;
    [SerializeField] private int structureSpawnRange;
    [SerializeField] private int entitySpawnRange;
    [SerializeField] private float perlinPos;
    [SerializeField] private float perlinZoomMultiplier;
    [SerializeField] private Vector2 xOffsetMinMax;
    [SerializeField] private Vector2 yOffsetMinMax;
    private Vector2 dirtSize;
    private Vector2 grassSize;
    private float perlinValue;
    private float xOffset;
    private float yOffset;
    private bool perlinDone = false;
    private float grassX;
    private float grassY;
    private int itemSpawnValue;
    private int structureSpawnValue;
    private int entitySpawnValue;

    private void Start()
    {
        dirtSize = new Vector2(dirtObj.transform.localScale.x, dirtObj.transform.localScale.y);
        grassSize = new Vector2(grassObj.transform.localScale.x, grassObj.transform.localScale.y);
        Generate();
    }

    private void Generate()
    {
        xOffset = Random.Range(xOffsetMinMax.x, xOffsetMinMax.y);
        yOffset = Random.Range(yOffsetMinMax.x, yOffsetMinMax.y);
        itemSpawnValue = Random.Range(0, itemSpawnRange);
        structureSpawnValue = Random.Range(0, structureSpawnRange);
        entitySpawnValue = Random.Range(0, entitySpawnRange);
        perlinPos = perlinPos > 0 ? perlinPos : 1;
        perlinZoomMultiplier = perlinZoomMultiplier > 0 ? perlinZoomMultiplier : 1;

        for (int i = 0; i < terrainWidth; i++)
        {
            for (int j = 0; j < terrainHeight; j++)
            {
                if (!perlinDone)
                {
                    perlinValue = Mathf.PerlinNoise(((genPoint.position.x + xOffset + i) * dirtSize.x) / perlinPos, ((genPoint.position.y + yOffset + j) * dirtSize.y) / perlinPos) * perlinZoomMultiplier;
                    perlinDone = true;
                }
                Instantiate<GameObject>(dirtObj, new Vector3((genPoint.position.x + i) * dirtSize.x, ((genPoint.position.y + j) * dirtSize.y) + perlinValue), Quaternion.identity);
            }
            grassX = (genPoint.position.x + i) * grassSize.x;
            grassY = ((genPoint.position.y + terrainHeight) * grassSize.y) + perlinValue;
            Instantiate<GameObject>(grassObj, new Vector3(grassX, grassY), Quaternion.identity);

            if (grassX == player.position.x)
            {
                SetPlayerY(grassY + playerYOffset);
            }

            if (Random.Range(0, itemSpawnRange) == itemSpawnValue)
            {
                int index = Random.Range(0, items.Length);
                SpawnPickup.Spawn(items[index].item, new Vector2(grassX, grassY + Random.Range(items[index].minY, items[index].maxY)));
            }

            if (Random.Range(0, structureSpawnRange) == structureSpawnValue)
            {
                int index = Random.Range(0, structures.Length - 1);
                Instantiate<GameObject>(structures[index].structure, new Vector3(grassX, grassY + structures[index].spawnY), Quaternion.identity);
            }

            if (Random.Range(0, entitySpawnRange) == entitySpawnValue)
            {
                int index = Random.Range(0, entities.Length - 1);
                SpawnPickup.Spawn(entities[index].entity, new Vector2(grassX, grassY + entities[index].spawnY));
            }
            perlinDone = false;
        }
    }

    private void SetPlayerY(float y)
    {
        player.position = new Vector3(player.position.x, y, player.position.z);
    }

    public float GetWidth()
    {
        return terrainWidth;
    }

    public Transform GetGenPoint()
    {
        return genPoint;
    }    
}
