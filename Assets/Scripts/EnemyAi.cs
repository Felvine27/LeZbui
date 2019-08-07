using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    private float Distance;

    private float DistanceBase;
    private Vector3 basePositions;

    public Transform Target;

    public float chaseRange = 10;

    public float attackRange = 1.0f;

    private UnityEngine.AI.NavMeshAgent agent;

    //private Animation animations;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //animations = gameObject.GetComponent<Animation>();
        basePositions = transform.position;
    }



    void Update()
    {

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


