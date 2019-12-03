using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Bullet; //Снаряд
    public Transform firePoint; //Точка, с которой будут отправляться снаряды и лучи

    public GameControl gameControl;
    public float speed = 20f;
    private Rigidbody2D rb;
    private bool isRightSide = true;
    public AudioSource ShootSound;
    //private Vector2 scale;
    //private Vector2 newscale;
    private float timer = 10.0f;
    public int PlayerHealth = 100;
    public Animator PlayerDead;
    public Animator PlayerShoot;
    public Animator anim;
    

    void Start()
    {
        float moveY = Input.GetAxis("Vertical");        
        //scale = new Vector2(rb.transform.localScale.x, rb.transform.localScale.y);
        //newscale = scale;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1")) //(&& !GameControl.isShooting) //Если игрок нажал на q
        {
            //Вызов метода стрельбы снарядами
            ShootBullet();
           // StartCoroutine(Shooting());
            
            //PlayerShoot.SetBool("isShooting", false);
            ShootSound.Play();

        }
        rb = GetComponent<Rigidbody2D>();
        float moveY = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime);

        //play moveAnimator
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isGrunyRun", true);
        }
        else
        {
            anim.SetBool("isGrunyRun", false);
        }
    }

    void ShootBullet()
    {
        GameObject newBull = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        newBull.GetComponent<Bullet>().gameControl = gameControl;
        GameControl.isShooting = true;
    }

    void Spin()
    {
        isRightSide = !isRightSide;

        transform.Rotate(0f, 180f, 0f); //Вращение персонажа по оси X на 180 градусов
    }

    void Dead()
    {

        if (PlayerHealth <= 0)
        {
            //PlayerDead.SetTrigger("isDead");
        }
    }

    /*/IEnumerator Shooting()
    {
        //Debug.Log("start shooting");
        PlayerShoot.SetBool("isShooting", true);        
        yield return new WaitForSeconds(0.5f);
        PlayerShoot.SetBool("isShooting", false);
       // Debug.Log("fin shooting");
    }/*/

}
