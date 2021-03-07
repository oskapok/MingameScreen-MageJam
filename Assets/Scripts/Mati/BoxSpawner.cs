using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> boxes;
    [SerializeField] private int maxBoxes;
    [SerializeField] private int minTimeOfSpawn;
    [SerializeField] private int maxTimeOfSpawn;
    private int randomTimeOfSpawn;
    private float timer = 0;

    void Update()
    {
        SpawnBoxes();
    }


    void SpawnBoxes()
    {
        if (GameObject.FindGameObjectsWithTag("Box").Length < maxBoxes)
        {
            timer += Time.deltaTime;
            if (timer > randomTimeOfSpawn)
            {
                randomTimeOfSpawn = Random.Range(minTimeOfSpawn, maxTimeOfSpawn);
                timer = 0;
                Vector2 spawn = new Vector2(Random.Range(spawnPoints[0].position.x, spawnPoints[1].position.x), spawnPoints[0].position.y);
                Instantiate(boxes[Random.Range(0, boxes.Count)], spawn, Quaternion.identity);
            }
        }
    }
}
