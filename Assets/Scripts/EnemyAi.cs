using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public bool wallk = false;   
    private float Distance;

    private float DistanceBase;
    private Vector3 basePositions;

    public Transform Target;

    public float chaseRange = 10;

    public float attackRange = 1.0f;

    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        basePositions = transform.position;
    }



    void Update()
    {

        if(GameObject.Find("Player").gameObject.activeInHierarchy)
            Target = GameObject.Find("Player").transform;

        Distance = Vector3.Distance(Target.position, transform.position);

        DistanceBase = Vector3.Distance(basePositions, transform.position);

        if (Distance < chaseRange && Distance > attackRange)
        {
            chase();
        }

        if (Distance < attackRange)
        {
            attack();
        }

        if (Distance > chaseRange && DistanceBase > 1)
        {
            BackBase();
        }

    }

    void chase()
    {
        agent.destination = Target.position;
        gameObject.GetComponent<Animator>().SetBool("walk", true);
    }

    void attack()
    {        
        agent.destination = transform.position;
    }

    public void BackBase()
    {
        agent.destination = basePositions;
    }

}


