using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameControl gameControl;
    public int health=100;
    public Animator ZomDead;
    public GameObject ZomCat;
    



    public void TakeDamage(int damage=1)
    {
        health -= damage ;
        if (health <= 0)
        {
            StartCoroutine(Zom());
            //Die();
            //Debug.Log(1);
        }
    }
    public void Die()
    {
        //StartCoroutine(Zom());
        
        
    }

    IEnumerator Zom()
    {
        
        ZomDead.SetTrigger("ZomDead");
        //Debug.Log("pleyerZomDie");
        yield return new WaitForSeconds(2f);  //задержка            
        //Debug.Log("ZomDie1");        
        Destroy(gameObject);
    }
}
