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
    private Vector2 scale;
    private Vector2 newscale;
    private float timer = 10.0f;

    void Start()
    {
        float moveY = Input.GetAxis("Vertical");        
        //scale = new Vector2(rb.transform.localScale.x, rb.transform.localScale.y);
        //newscale = scale;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //Если игрок нажал на q
        {
            //Вызов метода стрельбы снарядами
            ShootBullet();
            ShootSound.Play();
        }
        rb = GetComponent<Rigidbody2D>();
        float moveY = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + Vector2.up * moveY * speed * Time.deltaTime);

        /*/ уменьшение персонажа
        if (Vector3.up)
        {
            


        }/*/
    }

    void ShootBullet()
    {
        GameObject newBull = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        newBull.GetComponent<Bullet>().gameControl = gameControl;
    }

    void Spin()
    {
        isRightSide = !isRightSide;

        transform.Rotate(0f, 180f, 0f); //Вращение персонажа по оси X на 180 градусов
    }
}
