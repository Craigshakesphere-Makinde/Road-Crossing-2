using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public ActivateRagdoll activateRagdoll;
    private WheelCollider d;

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic= false;
        

    }



  

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("car"))
        {
            

            Debug.Log("Player has been hit");
            
            
            DeactivateComponent();
    
            GameOver gameOver= FindObjectOfType<GameOver>();
            gameOver.GameIsOver();
        }

    }

   
   

    private void DeactivateComponent()
    {
        Debug.Log("Deactivating");
        
        GetComponentInChildren<Animator>().enabled=false;
        GetComponent<CapsuleCollider>().enabled=false;
        GetComponent<Movement>().enabled=false;
        GetComponent<CharacterController>().enabled=false;
        
        activateRagdoll.Activate();
        //GetComponent<Rigidbody>().isKinematic=true;


    }
}
