using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    private float speed = 5f;
    private int damage = 1;

    private int life = 0;

    private int lifeMax = 500;
    public GameControl gameControl;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; //Изменение скорости
       
    }

    /*/void Update()
    {
        life++;

        if (life >= lifeMax)
        {
            Explode(); //Если снаряд пролетел определенное расстояние и ни с чем не столкнулся, его нужно удалить, чтобы он не расходовал ресурсы
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo) //Метод, который срабатывает при попадании
    {
        Explode();
    }
    */
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag.ToString().Contains("boll"))
        {
            Kill kill = hitInfo.GetComponent<Kill>();
            if (kill != null)
            {
                kill.TakeDamage(damage);
            }
           
            Destroy(gameObject); //Уничтожение объекта
            
        }

        if (hitInfo.gameObject.tag.ToString().Contains("ZomCat"))
        {
            Kill kill = hitInfo.GetComponent<Kill>();
            if (kill != null)
            {
                kill.TakeDamage(damage);
            }
            gameControl.score1();
            Destroy(gameObject); //Уничтожение объекта
            
        }



    }
}
