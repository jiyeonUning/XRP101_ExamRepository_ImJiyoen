using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;       // 총알을 발사하는 transform
    [SerializeField] private CustomObjectPool _bulletPool; // 총알 보관소
    [SerializeField] private float _fireCooltime;          // 총알 발사 쿨타임
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("실행됨");
        // 콜라이더 내부에 플레이어 오브젝트가 들어왔을 경우, 타겟을 향해 Fire 함수를 실행한다.
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    private void Init()
    {
        // 첫 실행 시, 코루틴은 비어있다.
        _coroutine = null;
        // 쿨타임을 설정하여 저장해둔다. (1.5초)
        _wait = new WaitForSeconds(_fireCooltime);
        // 총알 보관소에 총알을 만들어둔다.
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            // 1.5초에 한 번 씩, 아래 코드를 실행한다.
            yield return _wait;
            
            // 터렛의 각도를 플레이어를 향해 맞추고,
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );
            
            // 총알 오브젝트를 활성화 한다.
            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            // 생성된 총알 오브젝트는 머즐포인트 위치에 있는다.
            bullet.gameObject.transform.position = _muzzlePoint.position;
            // 어떤 기능인지 잘 모르겠다.
            bullet.OnTaken(target);
            
        }
    }

    private void Fire(Transform target)
    {
        // 타겟을 향해 총알이 발사되는 코루틴을 실행한다.
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
