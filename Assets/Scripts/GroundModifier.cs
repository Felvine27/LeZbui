using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GroundModifier : MonoBehaviour
{

    public NavMeshSurface surface;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //Destroy(gameObject, 5);
        yield return new WaitForSeconds(5f);
        surface.BuildNavMesh();
        Debug.Log("Le NavMesh a été updaté");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
