using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullet; //Снаряд
    public GameObject BulletFly;//2 Снаряд
    public Transform firePoint; //Точка, с которой будут отправляться снаряды и лучи
   
    public GameControl gameControl;
    public float speed = 20f;
    private Rigidbody2D rb;    
    public AudioSource ShootSound;    
    public int PlayerHealth = 100;    
    //public Animator GranyDead;
    public Animator anim;
    public static bool IsShootingNow = false;
    public bool going = true;
    public float yMin;
    public float yMax;

    int heightScreen = 0;
    void Start()
    {
        
        float moveY = Input.GetAxis("Vertical");
        anim = GetComponent<Animator>();        
        heightScreen = Screen.height;
       
    }

    void FixedUpdate()
    {
        //стрельба
        if (Input.GetButtonDown("Fire2") && !IsShootingNow)  //Если игрок нажал на e
        {

            //Вызов метода стрельбы снарядами            
            ShootBulletFly();
            ShootSound.Play();            
        }



            if (Input.GetButtonDown("Fire1") && !IsShootingNow)  //Если игрок нажал на q
            {

            //Вызов метода стрельбы снарядами
                StartCoroutine(GranyAttack());
                ShootBullet();                            
                ShootSound.Play();
            if (Input.GetButtonDown("Fire1") && !IsShootingNow)  //Если игрок повторно нажал на q
            {
                anim.SetBool("isGrunyAttack", false);
                StartCoroutine(GranyAttack());
                ShootBullet();
                ShootSound.Play();

            }



            //Debug.Log("GranyAttack");
        }


        //ходьба
        //Debug.Log(Camera.main.WorldToScreenPoint(transform.position));
        float yP = Camera.main.WorldToScreenPoint(transform.position).y;
        
        rb = GetComponent<Rigidbody2D>();
        float moveY = Input.GetAxis("Vertical");
        bool isMoveUp = true;

 

        if (Input.GetKey(KeyCode.UpArrow) && yP <= 560)
        {
            rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime);
            anim.SetBool("isGrunyRun", true);
            //anim.SetBool("isGrunyAttack", false);

        }
        else
        {
            anim.SetBool("isGrunyRun", false);
            
        }

        if (Input.GetKey(KeyCode.DownArrow) && yP >= 189)
        {
            rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime);
            anim.SetBool("isGrunyRun", true);
            //anim.SetBool("isGrunyAttack", false);
        }


                       
    }

    void ShootBullet()
    {
        
        GameObject newBull = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        newBull.GetComponent<Bullet>().gameControl = gameControl;
        GameControl.isShooting = true;
        IsShootingNow = true;
        
    }

    void ShootBulletFly()
    {        
        GameObject newBulletFly = Instantiate(BulletFly, firePoint.position, firePoint.rotation);
        newBulletFly.GetComponent<BulletFly>().gameControl = gameControl;
        GameControl.isShooting = true;
        IsShootingNow = true;
    }


    void Dead()
    {

        if (PlayerHealth <= 0)
        {
            //PlayerDead.SetTrigger("isDead");
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Contains("ZomCat"))
        {
            GameControl.isStopGame = true;
            anim.SetTrigger("dead");            
        }
                //gameControl.DestroyZomCat(this.gameObject);
                
    }

    IEnumerator GranyAttack()
    {
        
        anim.SetBool("isGrunyAttack", true);
        yield return new WaitForSeconds(0.001f); //задержка         
        anim.SetBool("isGrunyAttack", false);
        
    }

    

}
