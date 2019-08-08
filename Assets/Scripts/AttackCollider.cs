using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    private BoxCollider attackArea;
    private bool canAttack = true;

    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }

    public bool _isAttacking = false;

    public bool IsAttacking
    {
        get { return _isAttacking; }
        set { _isAttacking = value; }
    }

    [SerializeField]
    private float attackCooldownTime = 5.0F;

    [SerializeField]
    private float attackAreaDuration = 2.0F;

    private void Start()
    {
        attackArea = GetComponent<BoxCollider>();
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            AttackMethod();
        }
    }

    private void AttackMethod()
    {
        IsAttacking = true;
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
        attackArea.enabled = false;
        IsAttacking = false;
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

    private void OnTriggerEnter(Collider enemyCollided)
    {

        if (enemyCollided.CompareTag("Enemy"))
            Destroy(enemyCollided.gameObject);

    }
}
