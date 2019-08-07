using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackColliderEnemy : MonoBehaviour
{

    private BoxCollider attackArea;
    private bool canAttack = true;

    [SerializeField]
    private float attackCooldownTime = 3.0F;

    [SerializeField]
    private float attackAreaDuration = 2.0F;

    private void Start()
    {
        attackArea = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(canAttack)
            AttackMethod();
    }

    private void AttackMethod()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        canAttack = false;
        TriggerAttackCooldownCoroutine();
        attackArea.enabled = true;
        TriggerAttackTimerCoroutine();
    }

    public void TriggerAttackTimerCoroutine()
    {
        StartCoroutine(AttackTimerCoroutine());
    }

    private IEnumerator AttackTimerCoroutine()
    {    
        yield return new WaitForSeconds(attackAreaDuration);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        attackArea.enabled = false;

    }

    public void TriggerAttackCooldownCoroutine()
    {
        StartCoroutine(AttackCooldownCoroutine());
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldownTime);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider playerCollided)
    {

        if (playerCollided.CompareTag("Player"))
            SceneManager.LoadScene(0);

    }
}
