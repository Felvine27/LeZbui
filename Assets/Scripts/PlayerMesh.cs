using UnityEngine;
using UnityEngine.AI;

public class PlayerMesh : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Animator animator;

    private Vector3 mousePos;

    private bool isMoving = false;

    private Vector3 playerPos;

    private Animation attack;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && !FindObjectOfType<AttackCollider>().IsAttacking && FindObjectOfType<AttackCollider>().CanAttack)
        {

            animator.Play("Armature|Attack");

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
            animator.SetBool("run", true);


            Debug.Log("mousePos:" + mousePos.magnitude);
            Debug.Log("gameObject" + gameObject.transform.position.magnitude);

            //isMoving = true;

            //animator.SetBool("run", true);
            Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray1, out hit))
            {

                agent.SetDestination(hit.point);
            
            }
        }

        
        if (!agent.hasPath)
        {
            Debug.Log("Stop Run");
            animator.SetBool("run", false);
        }
        else
        {
            animator.SetBool("run", true);
        }

        if (!Physics.Raycast(gameObject.transform.position, gameObject.transform.position - new Vector3(gameObject.transform.position.x, 5F, gameObject.transform.position.z), 5F, layerMask))
        {

            GetComponent<NavMeshAgent>().enabled = false;

        }

        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position - gameObject.transform.up * 1.2f, Color.red, Time.deltaTime);

    }
}
