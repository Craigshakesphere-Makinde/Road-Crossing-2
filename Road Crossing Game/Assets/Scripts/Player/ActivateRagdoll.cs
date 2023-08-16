using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{

    [SerializeField] private GameObject[] bodies;
    [SerializeField] private Animator anime;

    void Start()
    {
        Deactivate();

        
    }
    
    // Start is called before the first frame update
    public void Activate()
    {
        anime.enabled=false;
        Debug.Log("It is has been activated");
        
        foreach( GameObject body in bodies)
        {
            if(body.GetComponent<CapsuleCollider>())
            {
                body.GetComponent<CapsuleCollider>().enabled= true;
                Debug.Log("A capsule collided has been activated");

            }
            if(body.GetComponent<Rigidbody>())
            {
                body.GetComponent<Rigidbody>().isKinematic= true;
                body.GetComponent<Rigidbody>().useGravity= true;
                Debug.Log("A rigid body has been activate");

            }
            if(body.GetComponent<BoxCollider>())
            {
                body.GetComponent<BoxCollider>().enabled=true;
            }
            
            
        }
        
        
    }

    private void Deactivate()
    {
        foreach(GameObject body in bodies)
        {
            body.GetComponent<Collider>().enabled=false;
            body.GetComponent<Rigidbody>().isKinematic= false;
            body.GetComponent<Rigidbody>().useGravity=false;
        }
    }
}
