using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    public Rigidbody2D rb;

    private float speed = 10f;
    private int damage = 1;
    public GameControl gameControl;
    public float Live = 2.0f;
    public float Timer = 0.0f;

    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; //Изменение скорости        
    }


    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Уничтожение печеньки
        if (hitInfo.gameObject.tag.ToString().Contains("boll"))
        {
            Kill kill = hitInfo.GetComponent<Kill>();
            if (kill != null)
            {
                kill.TakeDamage(damage);
            }

            Destroy(gameObject); //Уничтожение объекта            
            GameControl.isShooting = false;
            Player.IsShootingNow = false;

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
            GameControl.isShooting = false;
            Player.IsShootingNow = false;

        }
        StartCoroutine(DestroyCane());

    }

    //задержка перед удалением обьекта
    IEnumerator DestroyCane()
    {
        yield return new WaitForSeconds(0.001f);
        Timer += Time.deltaTime;
        if (Live < Timer)
        {
            Destroy(this.gameObject);
        }
    }
}
