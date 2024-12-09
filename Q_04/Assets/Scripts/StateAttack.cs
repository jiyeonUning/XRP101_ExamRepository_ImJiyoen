using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)
        {   
            // ���� ���� : ������ �ݶ��̴� �迭 �� IDamagable�� �����ϴµ�, ���� ShieldMonster���� IDamagable�� ����.
            // �ذ� ��� : ?�� ����, IDamagable�� ������ �Ϸ�Ǿ����� Ȯ�� ��, TakeHit �Լ��� ȣ���� �� �ֵ��� �Ѵ�.
            damagable = col.GetComponent<IDamagable>();
            damagable?.TakeHit(Controller.AttackValue); // = if (damagable != null �� ��, TakeHit �Լ� ȣ��)
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        Machine.ChangeState(StateType.Idle);
    }

}
