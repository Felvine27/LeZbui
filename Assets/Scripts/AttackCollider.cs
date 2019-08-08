﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{

    private BoxCollider attackArea;
    private bool canAttack = true;

    [SerializeField]
    private float attackCooldownTime = 5.0F;

    [SerializeField]
    private float attackAreaDuration = 2.0F;

    private void Start()
    {
        attackArea = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            AttackMethod();
        }
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
        attackArea.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public void TriggerAttackCooldownCoroutine()
    {
        StartCoroutine(AttackCooldownCoroutine());
    }

    private IEnumerator AttackCooldownCoroutine()
    {
        Debug.Log("Cooldown started");
        yield return new WaitForSeconds(attackCooldownTime);
        Debug.Log("Cooldown ended");
        canAttack = true;
    }

    private void OnTriggerEnter(Collider enemyCollided)
    {

        if (enemyCollided.CompareTag("Enemy"))
            Destroy(enemyCollided.gameObject);

    }
}
