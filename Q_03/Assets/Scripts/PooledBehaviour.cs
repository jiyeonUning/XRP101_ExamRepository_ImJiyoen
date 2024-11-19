using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PooledBehaviour : MonoBehaviour
{
    public Stack<PooledBehaviour> Pool { get; set; }

    public virtual void ReturnPool()
    {
        // ����� ���� �Ѿ� ������Ʈ�� �ٽ� Stack�� ����Ǹ�,
        Pool.Push(this);
        // ���� ��Ȱ��ȭ �Ѵ�.
        gameObject.SetActive(false);
    }

    public virtual void OnTaken<T>(T t)
    {
        Debug.Log("�����");
    }

    public virtual void OnTaken()
    {
    }
}
