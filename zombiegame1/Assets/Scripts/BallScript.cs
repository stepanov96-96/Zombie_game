using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public GameControl gameControl;
    public float speed = 1.0f;
     
    void OnTriggerEnter2D(Collider2D col)
    {
        
       
       gameControl.DestroyZomCat(this.gameObject);
       //Debug.Log("DestroyZomCat");
    }



}
