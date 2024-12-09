using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // = ()의 컴포넌트를 자동으로 추가시켜주는 []. 해당 코드가 존재할 경우, 임의로 컴포넌트의 삭제가 불가능하다.
public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force;          // 총알에 가해지는 힘
    [SerializeField] private float _deactivateTime; // 비활성화 까지 걸리는 시간
    [SerializeField] private int _damageValue;      // 데미지 값

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        // 벨로시티 초기화 기능
        _rigidbody.velocity = Vector3.zero;

        // 총알이 활성화 되었을 때, 다음 코루틴을 실행한다.
        StartCoroutine(DeactivateRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        // 총알이 플레이어 오브젝트에 닿았을 때,
        if (other.CompareTag("Player"))
        {
            other
                // 플레이어의 컨트롤러를 참조하여,
                .GetComponentInParent<PlayerController>()
                // 총알의 데미지 값 만큼 체력을 감소시키는 함수를 실행한다.
                .TakeHit(_damageValue);

            // + 이후 비활성화로 돌아간다.
            ReturnPool();
        }
    }

    private void Init()
    {
        // 총알이 비활성화 되는 주기를 저장한다.
        _wait = new WaitForSeconds(_deactivateTime);
        // rigidbody 컴포넌트를 참조한다.
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire()
    {
        // 총알 오브젝트는 앞 방향으로 force의 힘 만큼 발사된다.
        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        // 5초가 지난 후, 총알 오브젝트는 비활성화 되어 총알 보관소로 돌아간다.
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
        
        // 총알 오브젝트는 항상 플레이어 오브젝트를 바라보고 있다.
        transform.LookAt((t as Transform));
        // 해당 방향을 향해서 총알은 나아간다.
        Fire();
    }
}
