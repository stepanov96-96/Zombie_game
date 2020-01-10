using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    private float speed = 10f;
    private int damage = 1;
    public GameControl gameControl;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; //Изменение скорости
        StartCoroutine(BulletTime());
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
             

         }

        if (hitInfo.gameObject.tag.ToString().Contains("ZomCat"))
        {
            Kill kill = hitInfo.GetComponent<Kill>();
            if (kill != null)
            {
                kill.TakeDamage(damage);
            }
            gameControl.score1();
            
            
        }       

    }

    IEnumerator BulletTime()
    {
        //Debug.Log("start BulletTime");
        yield return new WaitForSeconds(0.01f);
        Destroy(this.gameObject);        
        GameControl.isShooting = false;
        Player.IsShootingNow = false;        
    }

}
