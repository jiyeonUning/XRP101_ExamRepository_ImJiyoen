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
            // 문제 요인 : 가져온 콜라이더 배열 중 IDamagable을 참조하는데, 기존 ShieldMonster에는 IDamagable이 없다.
            // 해결 방안 : ?를 통해, IDamagable이 참조가 완료되었는지 확인 후, TakeHit 함수를 호출할 수 있도록 한다.
            damagable = col.GetComponent<IDamagable>();
            damagable?.TakeHit(Controller.AttackValue); // = if (damagable != null 일 때, TakeHit 함수 호출)
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        Machine.ChangeState(StateType.Idle);
    }

}
