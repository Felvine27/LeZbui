using UnityEngine;
using UnityEngine.AI;

public class PlayerMesh : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Plane playerPlane = new Plane(Vector3.up, transform.position);

            float hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100.0F * Time.deltaTime);

            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray1, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
