using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    [SerializeField] private Transform genPoint;
    [SerializeField] private GameObject dirtObj;
    [SerializeField] private GameObject grassObj;
    [SerializeField] private float terrainWidth;
    [SerializeField] private float terrainHeight;
    [SerializeField] private GameObject[] pickupTypes;
    [SerializeField] private int pickupSpawnOdd;
    [SerializeField] private int randomPickupHeight;
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
        xOffset = Random.Range(1000, 5000);
        yOffset = Random.Range(1000, 5000);
        seed = Random.Range(0, pickupSpawnOdd);

        for (int i = 0; i < terrainWidth; i++)
        {
            for (int j = 0; j < terrainHeight; j++)
            {
                if (!perlinDone)
                {
                    perlinValue = Mathf.PerlinNoise(((genPoint.position.x + xOffset + i) * dirtSize.x) / 30, ((genPoint.position.y + yOffset + j) * dirtSize.y) / 30) * 10;
                    perlinDone = true;
                }
                Instantiate<GameObject>(dirtObj, new Vector3((genPoint.position.x + i) * dirtSize.x, ((genPoint.position.y + j) * dirtSize.y) + perlinValue), Quaternion.identity);
            }
            grassX = (genPoint.position.x + i) * grassSize.x;
            grassHeight = ((genPoint.position.y + terrainHeight) * grassSize.y) + perlinValue;
            GameObject grass = Instantiate<GameObject>(grassObj, new Vector3(grassX, grassHeight), Quaternion.identity);

            if (Random.Range(0, pickupSpawnOdd) == seed)
            {
                SpawnPickup.Spawn(pickupTypes[Random.Range(0, pickupTypes.Length)], new Vector2(grassX, grassHeight + Random.Range(1, randomPickupHeight)));
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
