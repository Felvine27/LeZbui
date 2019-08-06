using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 20f;
    public float jumpSpeed = 15f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController Cc;
    // Start is called before the first frame update
    void Start()
    {
        Cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cc.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), (Input.GetAxis("Jump")), Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        Cc.Move(moveDirection * Time.deltaTime);
 
    }
    
}
