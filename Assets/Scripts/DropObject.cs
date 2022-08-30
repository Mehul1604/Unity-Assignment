using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool hasReset;
    public float gravity = -9.8f;
    private Vector3 init_pos;
    private bool visible;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        init_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        isGrounded = controller.isGrounded;

        if(visible)
        {
            velocity.y += (gravity * Time.deltaTime);
            if(isGrounded && velocity.y < 0)
                velocity.y = -2f;
            
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            if(isGrounded)
            {
                transform.SetPositionAndRotation(init_pos , Quaternion.Euler(0 , 0 , 0));
                hasReset = true;
                velocity.y = 0;
            }
            else
            {
                if(!hasReset)
                {
                    velocity.y += (gravity * Time.deltaTime);
                    controller.Move(velocity * Time.deltaTime);
                }

            }
                
        }
        
        
    }
    void OnBecameVisible()
    {
        visible = true;
        hasReset = false;
        // Debug.Log(visible);
        
    }

    void OnBecameInvisible()
    {
        visible = false;
        
        // Debug.Log("Not visible");
    }
    
}
