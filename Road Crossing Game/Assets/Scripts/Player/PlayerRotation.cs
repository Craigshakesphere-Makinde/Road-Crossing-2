using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float vertical;

    private float horizontal;

    [SerializeField] private float rotSpeed;
    [SerializeField]
    private GameObject player;

    
    
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") *rotSpeed*Time.deltaTime;
        vertical = Input.GetAxis("Mouse Y");
        Mathf.Clamp(horizontal, -45f, 45f);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            player.transform.Rotate(Vector3.up*horizontal, Space.World);
            player.transform.Rotate(Vector3.left*vertical*Time.deltaTime, Space.Self);
            
            
           
        }
        

    }
}
