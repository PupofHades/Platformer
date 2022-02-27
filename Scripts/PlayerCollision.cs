using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision collisionInfo) 
    {
        if (collisionInfo.collider.tag =="Obstacle")
        {
            Debug.Log("FUCK2");
            FindObjectOfType<Gamemanager>().endgame();
        }    
    }
    
}
