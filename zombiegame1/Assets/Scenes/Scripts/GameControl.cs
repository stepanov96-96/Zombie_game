using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    
    public List<GameObject> ZomCatList = new List<GameObject>();
    private float spawnRangeX = 20;
    private Rigidbody2D rb;
    public float speed = 10;    
    public GameObject[] ZomCat;    
    public Transform[] spawnPoints;
    float LastTimeSpaw = 0f;
    float frequncySpaw = 1f;
    bool _IsSpawNow = true;    
    int CountadvNow = 0;
    int CurrentLevel = 0;
    public int level = 1;
    private int score;
    public Text ScoreText;
    public AudioSource Kill;
    private Animator ZomDie;
    public static bool isShooting = false;
    public static bool  isStopGame = false;
    public Animator ZomIdle;





    void Start()
    {
        //Debug.Log("Start");
        isStopGame = false;
        ZomIdle = GetComponent<Animator>();
    }

    void Spawn()
    {
        float rand = Random.Range(0.5f,3.35f);
        int RandCat = Random.Range(1, 5);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        GameObject newZomCat = Instantiate(ZomCat[RandCat], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);       
        BallScript t1 = newZomCat.GetComponent<BallScript>();
        Animator newZomCatAnim = newZomCat.GetComponent<Animator>();
        t1.speed = rand;
        newZomCatAnim.speed = t1.speed;
        t1.gameControl = this;        
        newZomCat.GetComponent<Kill>().gameControl = this;        
        ZomCatList.Add(newZomCat);
        CountadvNow++;
    }

    
    void FixedUpdate()
    {
        int SpawCat = 3;

        //пауза игры
        if (!isStopGame)
        {
           // Debug.Log("start");
            foreach (GameObject item in ZomCatList)
            {
                Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
                BallScript t1 = item.GetComponent<BallScript>();
                rb.MovePosition(rb.position + Vector2.left * speed * t1.speed * Time.deltaTime);
            }

            
            //задержка времени
            if (_IsSpawNow && LastTimeSpaw + frequncySpaw < Time.time && ZomCatList.Count < SpawCat )
            {
                SpawCat ++;
                Spawn();
                LastTimeSpaw = Time.time;

            }



            if (CountadvNow > 5 && CurrentLevel == 0)
            {
                _IsSpawNow = false;
                CurrentLevel++;
                _IsSpawNow = true;

            }
        }

        

    }

    public void score1()
    {

        score++;
        ScoreText.text = score+"";
       
        
    }
   
    public void DestroyZomCat(GameObject ZomCat)
    {
        for (int i = ZomCatList.Count - 1; i >= 0; i--)
        {
            if (ZomCatList[i].Equals(ZomCat))
            {                
                ZomCatList.RemoveAt(i);                
                ZomCat.GetComponent<BoxCollider2D>().enabled = false;
                Kill.Play();
                
            }
        }
    }

  

    



}
