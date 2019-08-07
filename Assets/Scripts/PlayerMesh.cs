using UnityEngine;
using UnityEngine.AI;

public class PlayerMesh : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    [SerializeField]
    private LayerMask layerMask;

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

            if (Physics.Raycast(ray1, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        if (!Physics.Raycast(gameObject.transform.position, gameObject.transform.position - new Vector3(gameObject.transform.position.x, 5F, gameObject.transform.position.z), 5F, layerMask))
        {

            GetComponent<NavMeshAgent>().enabled = false;

        }

        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position - gameObject.transform.up * 1.2f, Color.red, Time.deltaTime);

    }
}
