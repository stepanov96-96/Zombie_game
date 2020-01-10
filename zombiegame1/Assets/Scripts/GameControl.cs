using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControl : MonoBehaviour
{
    
    public List<GameObject> ZomCatList = new List<GameObject>();
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
    public AudioSource Kill;
    private Animator ZomDie;
    public static bool isShooting = false;
    public static bool  isStopGame = false;
    public static int MaxCatSpaw = 1;
    public static int CatSpawedFromStart = 0;
    public Animator ZomIdle;
     int SpawCat = 10;
    //текстовые значения
    //Счетчик убийств
    public int TimeSkore=5;
    public Text TimeText;
    //счетчик времени задержки
    private int Score;
    public Text ScoreText;
    //Счетчик уровней
    public int Level=1;
    public Text LevelPlus;



    void Start()
    {
        
        isStopGame = false;
        ZomIdle = GetComponent<Animator>();
    }

    void Spawn()
    {

        
        float rand = Random.Range(0.5f, 3.35f);
        int RandCat = Random.Range(0, 5);
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
        CatSpawedFromStart++;
        

    }


    void FixedUpdate()
    {


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

           //ebug.Log(SpawCat);
            //задержка времени
            if (_IsSpawNow && LastTimeSpaw + frequncySpaw < Time.time && CatSpawedFromStart < MaxCatSpaw && ZomCatList.Count < SpawCat)
            {
                
                Spawn();
                LastTimeSpaw = Time.time;                
            }


            if (CatSpawedFromStart >= MaxCatSpaw && ZomCatList.Count == 0)
            {                
                StartCoroutine(StopGame());
                CurrentLevel++;
                _IsSpawNow = false;                
            }

        }
        

    }

    public void score1()
    {
        Score++;
        ScoreText.text = Score+"";     
        
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


    IEnumerator StopGame()
    {
        CatSpawedFromStart = 0;
        //увеличение уровня
        Level++;
        LevelPlus.text = Level + "";
        StartCoroutine(TimeLevel());
        yield return new WaitForSeconds(5f);        
        MaxCatSpaw++;
        _IsSpawNow = true;
       // Debug.Log("cat++");
        

    }

    IEnumerator TimeLevel()
    {
        
        for(int i = 0; i < 5; i++) 
        {            
            TimeSkore--;
            TimeText.text = TimeSkore + "";
            
            yield return new WaitForSeconds(1f);
        };
        TimeSkore=5;
        TimeText.text = TimeSkore + "";

    }


    //--------------------------------------------кнопки для меню -------------------------------------------- 
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

   

    //кнопка продолжить
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //кнопка паузы
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //кнопка выхода в главное меню
    public void LoadMenu()
    {
        Debug.Log("menu");
    }

    //кнопка выхода 
    public void QuitGame()
    {
        Debug.Log("Quit");
    }

    //переход на другую сцену
    public void LoadScene(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
