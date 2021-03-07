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


    void Start()
    {
        //StartCoroutine(SpawnBoxes());
        int randomTimeOfSpawn = Random.Range(minTimeOfSpawn, maxTimeOfSpawn);
    }

    //IEnumerator SpawnBoxes()
    //{
    //    Instantiate(boxes[Random.Range(0, boxes.Count)], 
    //    //yield return new WaitForSeconds(randomTimeOfSpawn);
    //}
}
