using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public GameControl gameControl;
     
    void OnTriggerEnter2D(Collider2D col)
    {
        
       
       gameControl.DestroyZomCat(this.gameObject);
       //Debug.Log("DestroyZomCat");
    }



}
