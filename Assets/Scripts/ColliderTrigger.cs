using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rigidbodyTile;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {

        Debug.Log("Collided");

        if (collider.CompareTag("Player"))
            TriggerTileActivationCoroutine();
        
    }

    public void TriggerTileActivationCoroutine()
    {
        StartCoroutine(TileActivationCoroutine());
    }

    private IEnumerator TileActivationCoroutine()
    {
        yield return new WaitForSeconds(3.0F);
        rigidbodyTile.isKinematic = false;
    }

}
