using UnityEngine;

public class ScrapSpawner : MonoBehaviour {
    public float SpawnArea = 10;
    public int SpawnAmount = 10;
    public GameObject ScrapPrefab;
    void Start() {
        for (int i = 0; i < SpawnAmount; i++) {
            Instantiate(ScrapPrefab, Random.insideUnitCircle * SpawnArea, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
