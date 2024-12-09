using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // = ()�� ������Ʈ�� �ڵ����� �߰������ִ� []. �ش� �ڵ尡 ������ ���, ���Ƿ� ������Ʈ�� ������ �Ұ����ϴ�.
public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force;          // �Ѿ˿� �������� ��
    [SerializeField] private float _deactivateTime; // ��Ȱ��ȭ ���� �ɸ��� �ð�
    [SerializeField] private int _damageValue;      // ������ ��

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        // ���ν�Ƽ �ʱ�ȭ ���
        _rigidbody.velocity = Vector3.zero;

        // �Ѿ��� Ȱ��ȭ �Ǿ��� ��, ���� �ڷ�ƾ�� �����Ѵ�.
        StartCoroutine(DeactivateRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // �Ѿ��� �÷��̾� ������Ʈ�� ����� ��,
        if (other.CompareTag("Player"))
        {
            other
                // �÷��̾��� ��Ʈ�ѷ��� �����Ͽ�,
                .GetComponentInParent<PlayerController>()
                // �Ѿ��� ������ �� ��ŭ ü���� ���ҽ�Ű�� �Լ��� �����Ѵ�.
                .TakeHit(_damageValue);

            // + ���� ��Ȱ��ȭ�� ���ư���.
            ReturnPool();
        }
    }

    private void Init()
    {
        // �Ѿ��� ��Ȱ��ȭ �Ǵ� �ֱ⸦ �����Ѵ�.
        _wait = new WaitForSeconds(_deactivateTime);
        // rigidbody ������Ʈ�� �����Ѵ�.
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire()
    {
        // �Ѿ� ������Ʈ�� �� �������� force�� �� ��ŭ �߻�ȴ�.
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        // 5�ʰ� ���� ��, �Ѿ� ������Ʈ�� ��Ȱ��ȭ �Ǿ� �Ѿ� �����ҷ� ���ư���.
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;
        
        // �Ѿ� ������Ʈ�� �׻� �÷��̾� ������Ʈ�� �ٶ󺸰� �ִ�.
        transform.LookAt((t as Transform));
        // �ش� ������ ���ؼ� �Ѿ��� ���ư���.
        Fire();
    }
}
