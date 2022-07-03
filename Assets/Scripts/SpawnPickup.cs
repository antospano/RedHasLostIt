using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickup
{
    public static void Spawn(GameObject pickup, Vector2 spawnPos)
    {
        GameObject.Instantiate<GameObject>(pickup, spawnPos, Quaternion.identity);
    }
}
