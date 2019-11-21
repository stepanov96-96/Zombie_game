using UnityEngine;
using System.Collections;

public class spawnbaLL : MonoBehaviour
{
    public GameObject boll;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    //private float[] positions = {3.95f, 2.49f,-0.72f,-3.03f};
        void Start()
    {
        InvokeRepeating("Spawn",spawnTime,spawnTime);
        //StartCoroutine(spawn());

    }
    void Spawn() {
        /*/if (playerHealth<=0f){
          return;
          }*/
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(boll, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }





    /*/IEnumerator spawn() {
        while (true) {
            Instantiate(boll[Random.Range(10,50)],
                new Vector3(positions[Random.Range(0, 4)], -10f, -5),
               Quaternion.Euler(new Vector3(0, 0, -1))
                );
            yield return new WaitForSeconds(2.5f);
        }
    }/*/

}
