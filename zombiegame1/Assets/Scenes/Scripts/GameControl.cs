using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    //public List<GameObject> ballList = new List<GameObject>();
    public List<GameObject> ZomCatList = new List<GameObject>();
    private float spawnRangeX = 20;
    private Rigidbody2D rb;
    public float speed = 10;
    //public GameObject boll;
    public GameObject ZomCat;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    float LastTimeSpaw = 0f;
    float frequncySpaw = 3f;
    bool _IsSpawNow = true;
    //int CountBallNow = 0;
    int CountadvNow = 0;
    int CurrentLevel = 0;
    public int level = 1;

    private int score;
    public Text ScoreText;
    public AudioSource Kill;
    private Animator ZomDie;


    void Start()
    {
        Debug.Log("Start");
        //InvokeRepeating("SpawnRandomBoll", startDelay, spawnInterval);
        //rb = ballSingle.GetComponent<Rigidbody2D>();
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        //StartCoroutine(spawn());
        //int value = Random.Range(0, 100);
        //Debug.Log("rnd ="+value);

    }

    void Spawn()
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //GameObject newBall = Instantiate(boll, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        GameObject newZomCat = Instantiate(ZomCat, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        //BallScript tt = newBall.GetComponent<BallScript>();
        BallScript t1 = newZomCat.GetComponent<BallScript>();
        //tt.gameControl = this;
        t1.gameControl = this;
        //newBall.GetComponent<Kill>().gameControl = this;
        newZomCat.GetComponent<Kill>().gameControl = this;
        //ballList.Add(newBall);
        ZomCatList.Add(newZomCat);
        //CountBallNow++;
        CountadvNow++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*/foreach (GameObject item in ballList)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }/*/

        foreach (GameObject item in ZomCatList)
        {
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        }


        //задержка времени
        if (_IsSpawNow && LastTimeSpaw + frequncySpaw < Time.time)
        {
            Spawn();
            LastTimeSpaw = Time.time;
        }

        //количество мячей
        /*/if (CountBallNow > 5 && CurrentLevel == 0)
        {
            _IsSpawNow = false;
          CurrentLevel++;
            _IsSpawNow = true;
        }/*/

        if (CountadvNow > 5 && CurrentLevel == 0)
        {
            _IsSpawNow = false;
            CurrentLevel++;
            _IsSpawNow = true;
        }

    }

    public void score1()
    {

        score++;
        ScoreText.text = score+"";

    }


    //void SpawnRandomBall()
    //{
    //Debug.Log("SpawnRandomBol");
    //int ballIndex = Random.Range(0, ball.Length);
    //Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosz);
    //Instantiate(ball[ballIndex], spawnPos, ball[ballIndex].transform.rotation);

    //}

    /*/public void DestroyBall(GameObject ball)
    {
        for (int i = ballList.Count - 1; i >=0; i--)
        {
            if (ballList[i].Equals(ball))
            {
                ballList.RemoveAt(i);
                Destroy(ball);
            }
        }
    }/*/
    public void DestroyZomCat(GameObject ZomCat)
    {
        for (int i = ZomCatList.Count - 1; i >= 0; i--)
        {
            if (ZomCatList[i].Equals(ZomCat))
            {
                //ZomDie.SetTrigger("ZomDie");
                //StartCoroutine(Zom());
                ZomCatList.RemoveAt(i);
                //Destroy(ZomCat);
                // Die();
                
                Kill.Play();
                
            }
        }
    }
  

   
}
