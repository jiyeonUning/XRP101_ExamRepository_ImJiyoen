using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable] 
public class CustomObjectPool
{
    [SerializeField] private GameObject _pooledObject; // ������ �Ѿ� ������Ʈ�� �����Ѵ�.
    [SerializeField] private int _poolSize;            // �������� ũ�⸦ �����Ѵ�.
    private Stack<PooledBehaviour> _pool;              // �Ѿ��� �����ϴ� Stack Ŭ����

    public PooledBehaviour TakeFromPool()
    {
        PooledBehaviour target;

        if (_pool.Count == 0)
        {
            Debug.Log("�����");
            // Stack _pool�� ���� ���� ��, AddObject �Լ��� ����� target�� �����´�.
            target = AddObject();
            // �Ѿ� ������� ũ�⸦ 1ĭ �ø���.
            _poolSize++;
        }
        else
        {
            Debug.Log("�����");
            // ����� ���ο� �ڸ��� �����Ǿ� ���� ���, Stack ���� ó�� ����Ǿ� �ִ� PooledBehaviour target�� ��ȯ�Ͽ� �����´�.
            target = _pool.Pop();
        } 

        // else ���� ������ target�� ������Ʈ�� Ȱ��ȭ �Ͽ�, �Ѿ��� �߻��� �� �ִ�.
        target.gameObject.SetActive(true);
        
        return target;
    }
    
    public void CreatePool()
    {
        // �Ѿ� �������� ũ�� ��ŭ, _pool�� stack�� �����.
        _pool = new Stack<PooledBehaviour>(_poolSize);

        for (int i = 0; i < _poolSize; i++)
        {
            // ������� _pool�� �� ��ŭ �Ѿ��� �����Ѵ�.
            AddObject();
        }
    }

    private PooledBehaviour AddObject()
    {
        // �Ѿ� ������Ʈ�� ���� ��, ������ �Ѿ� ������Ʈ�� PooledVehaviour ������Ʈ�� ������ �����Ѵ�.
        PooledBehaviour target = MonoBehaviour.Instantiate(_pooledObject).GetComponent<PooledBehaviour>();
        // ������ ������Ʈ ������ Stack Pool�� �ش� ��ũ��Ʈ���� ������ �� �ֵ���, �� Stack�� �����ϰ�,
        target.Pool = _pool;
        // �ش� Stack ���� �Ѿ� ������Ʈ�� �߰��Ѵ�.
        _pool.Push(target);
        // �̷��� ������ �Ѿ� ������Ʈ���� ��Ȱ��ȭ ���·� �д�.
        target.gameObject.SetActive(false);
        
        // �Ѿ� ������Ʈ ������ PooledBehaviour Ŭ������ target�� �����Ѵ�.
        return target;
    }
}
