using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
     �־��� ������Ʈ�� ������ ����� �����ϰ��� ������ ������Ʈ�̴�.

     1. Player
     ���� ������ ����� Idle ���¿� Attack ���¸� �����Ѵ�.
     Idle���¿��� Q�� ������ Attack ���·� �����Ѵ�
     ���� �� 2�� ���� ������ ���� ���� ���� �ִ� �������� ���� �� �ִ� ���� Ž���� �������� �ο��ϰ� Idle���·� ���ƿ´�

     ���� �ӽ� : �� ���µ��� �����ϴ� ��ü�̸�, ���� ù��°�� �Է¹��� ���¸� �⺻ ���·� �����Ѵ�.

     2. NormalMonster
     �������� ���� �� �ִ� ����

     3. ShieldeMonster
     �������� ���� �ʴ� ����
     �� ��ɵ��� �����ϰ��� �� �� ���õ� ������Ʈ���� �߻��ϴ� �������� ��� �����ϰ� �ùٸ��� �����ϵ��� �ҽ��ڵ带 �����Ͻÿ�.
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
