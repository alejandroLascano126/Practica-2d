using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Transform tarjet;

    public Vector3 initTarjetPosition;
    public float minTime = 1f;
    public float maxTime = 2f;

    void Start()
    {
        initTarjetPosition = tarjet.position;
        StartCoroutine(SpawnCoRutine(0));
    }

    IEnumerator SpawnCoRutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        print($"transform position x: {transform.position.x} and transform position y: {transform.position.y}");

        float y = Random.Range(initTarjetPosition.y, 5);

        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], new Vector3(tarjet.position.x + 10, y, 0), Quaternion.identity);

        StartCoroutine(SpawnCoRutine(Random.Range(minTime, maxTime)));
    }

    
}
