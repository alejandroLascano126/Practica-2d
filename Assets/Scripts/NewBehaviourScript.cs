using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public Transform tarjet;
    public Vector3 initTarjetPosition;
    public float avanceTarjet;
    public float minTime = 1f;
    public float maxTime = 2f;
    public int contador = 0;

    float x;

    // Start is called before the first frame update
    void Start()
    {
        initTarjetPosition = tarjet.position;
        x = transform.position.x;
        StartCoroutine(SpawnCoRutine(0));
    }

    IEnumerator SpawnCoRutine(float waitTime)
    {
        avanceTarjet = tarjet.position.x - initTarjetPosition.x;
        print($"transform position x: {transform.position.x} and transform position y: {transform.position.y}");

        yield return new WaitForSeconds(waitTime);

        float y = Random.Range(initTarjetPosition.y, initTarjetPosition.y);

        x += avanceTarjet;

        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], new Vector3(x, y, 0), Quaternion.identity);
        if(contador < 100)
        {
            StartCoroutine(SpawnCoRutine(0));
        }
        contador++;

        
    }
}
