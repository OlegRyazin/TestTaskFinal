using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> roadPrefabs = new List<GameObject>();
    public Transform playerTransform;
    private float roadLength = 9f;

    private GameObject lastRoad;

    private void Start()
    {
        SpawnStartRoad();
    }

    private void Update()
    {
        if (playerTransform.position.x > lastRoad.transform.position.x + roadLength && Player.isGameRun) ReSpawnRoad();
    }

    public void SpawnStartRoad()
    {
        lastRoad = roadPrefabs[0];
        float x = 0;
        for (int i = 0; i < roadPrefabs.Count; i++)
        {
            roadPrefabs[i].transform.position = new Vector3(x, 0, 0);
            x += roadLength;
        }
    }

    private void ReSpawnRoad()
    {
        lastRoad.transform.position += new Vector3(roadLength * 4, 0, 0);
        int nextIndex = roadPrefabs.IndexOf(lastRoad) + 1;
        if (nextIndex == 4) nextIndex = 0;
        lastRoad = roadPrefabs[nextIndex];
    }
}
