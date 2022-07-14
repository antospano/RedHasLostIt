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

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField] private Transform genPoint;
    [SerializeField] private GameObject dirtObj;
    [SerializeField] private GameObject grassObj;
    [SerializeField] private float terrainWidth;
    [SerializeField] private float terrainHeight;
    [SerializeField] private Item[] items;
    [SerializeField] private int itemSpawnRange;
    [SerializeField] private float perlinPos;
    [SerializeField] private float perlinZoomMultiplier;
    [SerializeField] private Vector2 xOffsetMinMax;
    [SerializeField] private Vector2 yOffsetMinMax;
    //[SerializeField] private int randomItemHeight;
    private Vector2 dirtSize;
    private Vector2 grassSize;
    private float perlinValue;
    private float xOffset;
    private float yOffset;
    private bool perlinDone = false;
    private float grassX;
    private float grassHeight;
    private int seed;

    private void Start()
    {
        dirtSize = new Vector2(dirtObj.transform.localScale.x, dirtObj.transform.localScale.y);
        grassSize = new Vector2(grassObj.transform.localScale.x, grassObj.transform.localScale.y);
        Generate();
    }

    public void Generate()
    {
        xOffset = Random.Range(xOffsetMinMax.x, xOffsetMinMax.y);
        yOffset = Random.Range(yOffsetMinMax.x, yOffsetMinMax.y);
        seed = Random.Range(0, itemSpawnRange);
        perlinPos = perlinPos > 0 ? perlinPos : 1;
        perlinZoomMultiplier = perlinZoomMultiplier > 0 ? perlinZoomMultiplier : 1;

        for (int i = 0; i < terrainWidth; i++)
        {
            for (int j = 0; j < terrainHeight; j++)
            {
                if (!perlinDone)
                {
                    perlinValue = Mathf.PerlinNoise(((genPoint.position.x + xOffset + i) * dirtSize.x) / perlinPos, ((genPoint.position.y + yOffset + j) * dirtSize.y) / perlinPos) * perlinZoomMultiplier; // / 30 overall * 10
                    //perlinValue = PerlinManager.TerrainPerlinValue(genPoint, new Vector2(1000, 5000), new Vector2(1000, 5000), dirtSize, grassSize, itemSpawnRange, new Vector2(i, j));
                    perlinDone = true;
                }
                Instantiate<GameObject>(dirtObj, new Vector3((genPoint.position.x + i) * dirtSize.x, ((genPoint.position.y + j) * dirtSize.y) + perlinValue), Quaternion.identity);
            }
            grassX = (genPoint.position.x + i) * grassSize.x;
            grassHeight = ((genPoint.position.y + terrainHeight) * grassSize.y) + perlinValue;
            GameObject grass = Instantiate<GameObject>(grassObj, new Vector3(grassX, grassHeight), Quaternion.identity);

            if (Random.Range(0, itemSpawnRange) == seed)
            {
                int index = Random.Range(0, items.Length);
                SpawnPickup.Spawn(items[index].item, new Vector2(grassX, grassHeight + Random.Range(items[index].minY, items[index].maxY)));
                //Instantiate<GameObject>(pickupTypes[0], grass.transform.position, Quaternion.identity);
            }
            perlinDone = false;
        }
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
