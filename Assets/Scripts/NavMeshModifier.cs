using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshModifier : MonoBehaviour
{
    public NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void NavMeshModified()
    {
        surface.BuildNavMesh();
        Debug.Log("Le NavMesh a été mis à jour");
    }
}
