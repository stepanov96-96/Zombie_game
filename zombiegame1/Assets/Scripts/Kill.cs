using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameControl gameControl;
    public static float health=1f;
    public Animator ZomDead;
    public Animator Zom1;
    //public GameObject ZomCat;

    void Start()
    {
        ZomDead = GetComponent<Animator>();
    }


    public void TakeDamage(int damage = 1)
    {
       
        health -= damage ;
        if (health <= 0)
        {
            Debug.Log("helth");
            StartCoroutine(Zom());
            
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag.Contains("Player"))
        {
            
            ZomDead.SetBool("idle",true);
        }
        

    }

    IEnumerator Zom()
    {
        
        ZomDead.SetTrigger("ZomDead");        
        yield return new WaitForSeconds(1f); //задержка         
        //StartCoroutine(ZomDie());
        Destroy(gameObject);
    }
   
}
