using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Espaco : MonoBehaviour
{

    public int total_asteroides = 60;
    public float speed = 1.0f;

    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;

    void Start()
    {

        for (int i = 0; i < total_asteroides; i++)
        {
            float spawnPointX = Random.Range(-20.0f, 20.0f);
            float spawnPointY = Random.Range(-20.0f, 20.0f);
            float spawnPointZ = Random.Range(-20.0f, 20.0f);
            GameObject asteroid = asteroid1;
            Vector3 spawnPos = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
            if (i%3 == 0)
            {
                asteroid = asteroid1;
            }
            if (i % 3 == 1)
            {
                asteroid = asteroid2;
            }
            if (i % 3 == 2)
            {
                asteroid = asteroid3;
            }
            GameObject objeto = Instantiate(asteroid, spawnPos, Quaternion.identity);
            objeto.transform.parent = gameObject.transform;

            float spawnDirX = Random.Range(-1.0f, 1.0f);
            float spawnDirY = Random.Range(-1.0f, 1.0f);
            float spawnDirZ = Random.Range(-1.0f, 1.0f);
            float speed = Random.Range(-1.0f, 1.0f);
            Vector3 spawnDirection = new Vector3(spawnDirX, spawnDirY, spawnDirZ);
            objeto.GetComponent<Rigidbody>().velocity = speed * spawnDirection;
        }
    }
}

