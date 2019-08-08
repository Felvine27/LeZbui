using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackColliderEnemy : MonoBehaviour
{

    private BoxCollider attackArea;
    private bool canAttack = true;

    [SerializeField]
    private Animator animator;

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
        canAttack = false;
        TriggerAttackCooldownCoroutine();


        animator.SetBool("attack", true);

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
        attackArea.enabled = false;
        animator.SetBool("attack", false);

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
            LifeManager.LifePoints--;

        if (LifeManager.LifePoints == 0)
        {
            SceneManager.LoadScene(0);
            LifeManager.LifePoints = 3;
        }
    }
}
