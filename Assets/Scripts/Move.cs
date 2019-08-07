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

    public LayerMask whichLayerAreHit;
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Rotate");
            Vector3 cameraStartPoint = Camera.main.ViewportToWorldPoint(Input.mousePosition);
            RaycastHit hit;
            if ( Physics.Raycast(cameraStartPoint, Camera.main.transform.forward, out hit, float.MaxValue, whichLayerAreHit))
            {
                transform.LookAt(hit.point);
            }

        }
 
    }

    //Plane playerPlane = new Plane(Vector3.up, transform.position);

    //// Generate a ray from the cursor position
    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //// Determine the point where the cursor ray intersects the plane.
    //// This will be the point that the object must look towards to be looking at the mouse.
    //// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
    ////   then find the point along that ray that meets that distance.  This will be the point
    ////   to look at.
    //float hitdist = 0.0f;
    //    // If the ray is parallel to the plane, Raycast will return false.
    //    if (playerPlane.Raycast (ray, out hitdist)) 
    //    {
    //        // Get the point along the ray that hits the calculated distance.
    //        Vector3 targetPoint = ray.GetPoint(hitdist);

    //// Determine the target rotation.  This is the rotation if the transform looks at the target point.
    //Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

    //// Smoothly rotate towards the target point.
    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed* Time.deltaTime);
    //    }
    
}
