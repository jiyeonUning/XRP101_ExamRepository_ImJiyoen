using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PooledBehaviour : MonoBehaviour
{
    public Stack<PooledBehaviour> Pool { get; set; }

    public virtual void ReturnPool()
    {
        // 사용이 끝난 총알 오브젝트는 다시 Stack에 저장되며,
        Pool.Push(this);
        // 이후 비활성화 한다.
        gameObject.SetActive(false);
    }

    public virtual void OnTaken<T>(T t)
    {
        Debug.Log("실행됨");
    }

    public virtual void OnTaken()
    {
    }
}
