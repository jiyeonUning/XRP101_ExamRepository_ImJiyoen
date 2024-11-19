using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;       // �Ѿ��� �߻��ϴ� transform
    [SerializeField] private CustomObjectPool _bulletPool; // �Ѿ� ������
    [SerializeField] private float _fireCooltime;          // �Ѿ� �߻� ��Ÿ��
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�����");
        // �ݶ��̴� ���ο� �÷��̾� ������Ʈ�� ������ ���, Ÿ���� ���� Fire �Լ��� �����Ѵ�.
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    private void Init()
    {
        // ù ���� ��, �ڷ�ƾ�� ����ִ�.
        _coroutine = null;
        // ��Ÿ���� �����Ͽ� �����صд�. (1.5��)
        _wait = new WaitForSeconds(_fireCooltime);
        // �Ѿ� �����ҿ� �Ѿ��� �����д�.
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            // 1.5�ʿ� �� �� ��, �Ʒ� �ڵ带 �����Ѵ�.
            yield return _wait;
            
            // �ͷ��� ������ �÷��̾ ���� ���߰�,
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );
            
            // �Ѿ� ������Ʈ�� Ȱ��ȭ �Ѵ�.
            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            // ������ �Ѿ� ������Ʈ�� ��������Ʈ ��ġ�� �ִ´�.
            bullet.gameObject.transform.position = _muzzlePoint.position;
            // � ������� �� �𸣰ڴ�.
            bullet.OnTaken(target);
            
        }
    }

    private void Fire(Transform target)
    {
        // Ÿ���� ���� �Ѿ��� �߻�Ǵ� �ڷ�ƾ�� �����Ѵ�.
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
