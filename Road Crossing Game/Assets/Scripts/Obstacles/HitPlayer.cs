using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    [SerializeField] private float explosionForce=30f;
    [SerializeField] private float explosionRadius=10f;

    [SerializeField] private float upwardsModifier=.5f;

    [SerializeField] private Rigidbody meshBody;

    public ActivateRagdoll activateRagdoll;
  

    void Start()
    {
        GetComponent<Rigidbody>().isKinematic= false;
        

    }



  

    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("car"))
        {
            

            Debug.Log("Player has been hit");
            
            
            DeactivateComponent();

            yield return new WaitForSeconds(3f);
    
            // GameOver gameOver= FindObjectOfType<GameOver>();
            // gameOver.GameIsOver();
        }

        else if(collider.gameObject.CompareTag("Bombs"))
        {
            Debug.Log("Has meet with a bomb");
            
            DeactivateComponent();
            BombEffect();
            
            yield return new WaitForSeconds(3f);

            // GameOver gameOver= FindObjectOfType<GameOver>();
            // gameOver.GameIsOver();
        }

    }

   
   
    public void DeactivateComponent()
    {
        Debug.Log("Deactivating");
        
        GetComponentInChildren<Animator>().enabled=false;
        GetComponent<CapsuleCollider>().enabled=false;
        GetComponent<Movement>().enabled=false;
        GetComponent<CharacterController>().enabled=false;
        
        activateRagdoll.Activate();
        //GetComponent<Rigidbody>().isKinematic=true;


    }

    private void BombEffect()
    {
        Debug.Log("Bomb Effect was added");
        meshBody.isKinematic=false;
        meshBody.useGravity=false;
        //meshBody.AddExplosionForce(explosionForce, transform.position,explosionRadius,upwardsModifier);
        meshBody.GetComponent<Rigidbody>().AddForce(Vector3.up*50, ForceMode.Force);
    }
}
