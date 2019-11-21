using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    public GameControl gameControl;
    public int health = 1;
    public Animator ZomDead;


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log(1);
            Die();
        }
    }
    public void Die()
    {
        StartCoroutine(Zom());
        
        
    }

    IEnumerator Zom()
        {
        
        ZomDead.SetTrigger("ZomDead");
        Debug.Log("pleyerZomDie");
        yield return new WaitForSeconds(2f);  //задержка
        Debug.Log("ZomDie1");
        Destroy(gameObject);
    }
}
