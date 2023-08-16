using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    


    
    
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Debug.Log("It has hit player");

            DeactivateComponent(other);
            other.collider.GetComponent<ActivateRagdoll>().Activate();

            
            
            
            GameOver gameOver= FindObjectOfType<GameOver>();
            gameOver.GameIsOver();
        }
       
    }

    private void DeactivateComponent(Collision other)
    {
        Debug.Log("Deactivating");
        
        other.collider.GetComponent<CapsuleCollider>().enabled=false;
        other.collider.GetComponent<Movement>().enabled=false;
        other.collider.GetComponent<CharacterController>().enabled=false;


    }
}
