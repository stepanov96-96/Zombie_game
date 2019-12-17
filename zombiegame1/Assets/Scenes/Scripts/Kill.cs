using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameControl gameControl;
    public float health=0f;
    public Animator ZomDead;
    public Animator ZomCat;
    //public GameObject ZomCat;

    void Start()
    {
        ZomDead = GetComponent<Animator>();
    }


    public void TakeDamage(int damage=1)
    {
        health++;
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
        yield return new WaitForSeconds(1f); //задержка         
        StartCoroutine(ZomDie());
        Destroy(gameObject);
    }

    IEnumerator ZomDie()
    {
        
        yield return new WaitForSeconds(20f);//задержка
        Destroy(gameObject);            

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //StartCoroutine(IdleZomCat());
        //ZomDead.SetTrigger("idle");
        //Debug.Log("StopCats");
    }
}
