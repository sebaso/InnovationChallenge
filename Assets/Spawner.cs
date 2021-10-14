using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] slimes;
    public Transform[] spawns;
    public float timer;
    public float spawnTime;
    public float timetospawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            GameObject slime = Instantiate(slimes[Random.Range(0, slimes.Length)], spawns[Random.Range(0,spawns.Length)]);
            slime.transform.localPosition = Vector3.zero;
           
            timer = timetospawn;
        }
        
        
    }
}
