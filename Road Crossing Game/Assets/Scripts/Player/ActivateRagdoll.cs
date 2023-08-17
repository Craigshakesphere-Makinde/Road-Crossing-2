using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{

    
    private Collider[] ragdollCollider;
    private Rigidbody[] ragDollbody;

    void Start()
    {
        GetRagDolls();
        Deactivate();

        
    }
    
    // Start is called before the first frame update
    public void Activate()
    {
        
        Debug.Log("It is has been activated");
        
        foreach( Collider collider in ragdollCollider)
        {

            collider.enabled=true;
       
        }
        foreach(Rigidbody body in ragDollbody)
        {
            body.isKinematic= false;
        }
        
        
    }

    private void Deactivate()
    {
        foreach(Collider collider in ragdollCollider)
        {
            Debug.Log("Deactivating");
            collider.enabled= false;
            
        }

        foreach(Rigidbody body in ragDollbody)
        {
            body.isKinematic= true;
        }
    }

    private void GetRagDolls()
    {
        ragdollCollider= GetComponentsInChildren<Collider>();
        ragDollbody= GetComponentsInChildren<Rigidbody>();

    }
}
