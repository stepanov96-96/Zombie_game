using UnityEngine;
using System.Collections;

public class spawnbaLL : MonoBehaviour
{
    public GameObject boll;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    
        void Start()
    {
        InvokeRepeating("Spawn",spawnTime,spawnTime);
        

    }
    void Spawn() {
        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(boll, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }


}
