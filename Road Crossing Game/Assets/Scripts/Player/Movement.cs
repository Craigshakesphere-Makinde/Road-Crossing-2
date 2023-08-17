using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private float rotSpeed=.3f;
    [SerializeField] private string MoveForwardAnime, moveBackwardAnime,jumpAnime;
    [SerializeField] private Animator player;
    public CharacterController controller;
    public AudioSource run;

   
    private float horizontalInput;
    private float verticalInput;
    public float moveForce;
    public float jumpForce;

    [SerializeField]
    private  float gravity=9.8f;

    [SerializeField] public GameObject groundCheck;

    private bool isGrounded;

    private bool jumpKeyWasPresssed;
    private bool moveKeyWasPressed;

    private bool faceForward;
   
    

    // Start is called before the first frame update
    void Start()
    {
        
        faceForward=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

    }
    

    private void MyInput()
    {
        float acceleration= 0.5f* gravity*Time.deltaTime;
        controller.Move(Vector3.down* acceleration);
        

        // bool checkLeft = EnvironmentBounds.IsLeftMoveable;
        // if (checkLeft && Input.GetKey(KeyCode.LeftArrow))
        // {
        //     controller.Move(Vector3.left*moveForce*Time.deltaTime);
        // }
        // bool checkRIght= EnvironmentBounds.IsRightMoveable;
        // if (checkRIght && Input.GetKey(KeyCode.RightArrow))
        // {
        //     controller.Move(Vector3.right * moveForce * Time.deltaTime);
        // }




        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(!faceForward)
            {
                playerMesh.transform.Rotate(new Vector3(0,180,0));
                
            }
            controller.Move(transform.forward  * moveForce * Time.deltaTime);
            faceForward= true;
            
            player.Play(MoveForwardAnime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            
            if(faceForward)
            {
                playerMesh.transform.Rotate(new Vector3(0,180,0) );
            }
            
            controller.Move(Vector3.back  * moveForce * Time.deltaTime);
            
            faceForward=false;
            player.Play(MoveForwardAnime);

        }
        jumpKeyWasPresssed = Input.GetKeyDown(KeyCode.Space);

        
        if (Physics.OverlapSphere(groundCheck.transform.position,0.1f ).Length == 2)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(isGrounded  && jumpKeyWasPresssed)
        {
            controller.Move(Vector3.up*jumpForce*Time.deltaTime);
            player.Play(jumpAnime);
        }

       

        
        
        

    }


     private void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(groundCheck.transform.position, 0.1f);
     }
}
