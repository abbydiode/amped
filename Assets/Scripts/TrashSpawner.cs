using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public float SpawnArea = 10;
    public int SpawnAmount = 10;
    public GameObject ScrapPrefab;

    //WIP (Fabio 29/03): This script will be responsible to spawn all trash around the map, for now I am starting with Paper only. Good approach? Or one script for each resource?
    void Start()
    {
        for (int i = 0; i < SpawnAmount; i++)
        {
            Instantiate(ScrapPrefab, Random.insideUnitCircle * SpawnArea, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
