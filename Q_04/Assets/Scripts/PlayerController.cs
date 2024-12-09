using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

     1. Player
     상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
     Idle상태에서 Q를 누르면 Attack 상태로 진입한다
     진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다

     상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

     2. NormalMonster
     데미지를 입을 수 있는 몬스터

     3. ShieldeMonster
     데미지를 입지 않는 몬스터
     위 기능들을 구현하고자 할 때 제시된 프로젝트에서 발생하는 문제들을 모두 서술하고 올바르게 동작하도록 소스코드를 개선하시오.
     */


    [field: SerializeField] [field: Range(0, 30)] public float AttackRadius { get; private set; }
    [field: SerializeField] public int AttackValue { get; private set; }

    private StateMachine _state;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _state.OnUpdate();
    }

    private void Init()
    {
        _state = new StateMachine(new StateIdle(this), new StateAttack(this));
    }
}
