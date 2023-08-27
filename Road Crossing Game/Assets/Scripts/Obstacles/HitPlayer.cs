using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] bombEffect;
    [SerializeField] private float explosionForceUp=30f;
    [SerializeField] private float explosionForceBack=25;
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
            
            //DeactivateComponent();
         
            StartCoroutine(BombEffect());
            
            yield return new WaitForSeconds(3f);

            // GameOver gameOver= FindObjectOfType<GameOver>();
            // gameOver.GameIsOver();
        }

        else if(collider.gameObject.CompareTag("Pole"))
        {
            Debug.Log("Has meet with a bomb");
            
            //DeactivateComponent();
         
            StartCoroutine(ShockEffect());
            
            yield return new WaitForSeconds(3f);

        }

    }

   
   
    public void DeactivateComponent()
    {
       // Debug.Log("Deactivating");
        
        GetComponentInChildren<Animator>().enabled=false;
        GetComponent<CapsuleCollider>().enabled=false;
        GetComponent<Movement>().enabled=false;
        GetComponent<CharacterController>().enabled=false;
        
        activateRagdoll.Activate();
        


    }

    IEnumerator BombEffect()
    {
        
        //Debug.Log("Bomb Effect was added");
        meshBody.isKinematic=false;
        meshBody.useGravity=true;
        //meshBody.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position,explosionRadius,upwardsModifier);
        GameObject bomb= Instantiate(bombEffect[0], transform.position, Quaternion.identity);
        Destroy(bomb, .2f);
        meshBody.GetComponent<Rigidbody>().AddForce(Vector3.up*explosionForceUp, ForceMode.Impulse);

        yield return new WaitForSeconds(.1f);
        DeactivateComponent();
    }

    IEnumerator ShockEffect()
    {
        //Debug.Log("Shock Effect was added");
        meshBody.isKinematic=false;
        meshBody.useGravity=true;
        //meshBody.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position,explosionRadius,upwardsModifier);
        GameObject bomb= Instantiate(bombEffect[1], transform.position, Quaternion.identity);
        Destroy(bomb, .2f);
        meshBody.GetComponent<Rigidbody>().AddForce(Vector3.up*explosionForceBack, ForceMode.Impulse);

        yield return new WaitForSeconds(.08f);
        DeactivateComponent();

    }
}
