using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable] 
public class CustomObjectPool
{
    [SerializeField] private GameObject _pooledObject; // 생성할 총알 오브젝트를 저장한다.
    [SerializeField] private int _poolSize;            // 보관소의 크기를 설정한다.
    private Stack<PooledBehaviour> _pool;              // 총알을 보관하는 Stack 클래스

    public PooledBehaviour TakeFromPool()
    {
        PooledBehaviour target;

        if (_pool.Count == 0)
        {
            Debug.Log("실행됨");
            // Stack _pool의 수가 없을 때, AddObject 함수에 저장된 target을 가져온다.
            target = AddObject();
            // 총알 저장소의 크기를 1칸 늘린다.
            _poolSize++;
        }
        else
        {
            Debug.Log("실행됨");
            // 저장소 내부에 자리가 생성되어 있을 경우, Stack 가장 처음 저장되어 있던 PooledBehaviour target을 반환하여 가져온다.
            target = _pool.Pop();
        } 

        // else 에서 가져온 target의 오브젝트를 활성화 하여, 총알을 발사할 수 있다.
        target.gameObject.SetActive(true);
        
        return target;
    }
    
    public void CreatePool()
    {
        // 총알 보관소의 크기 만큼, _pool의 stack를 만든다.
        _pool = new Stack<PooledBehaviour>(_poolSize);

        for (int i = 0; i < _poolSize; i++)
        {
            // 만들어진 _pool의 수 만큼 총알을 생성한다.
            AddObject();
        }
    }

    private PooledBehaviour AddObject()
    {
        // 총알 오브젝트를 생성 후, 생성된 총알 오브젝트의 PooledVehaviour 컴포넌트를 가져와 저장한다.
        PooledBehaviour target = MonoBehaviour.Instantiate(_pooledObject).GetComponent<PooledBehaviour>();
        // 저장한 컴포넌트 내부의 Stack Pool을 해당 스크립트에서 관리할 수 있도록, 두 Stack을 연동하고,
        target.Pool = _pool;
        // 해당 Stack 내에 총알 오브젝트를 추가한다.
        _pool.Push(target);
        // 이렇게 생성된 총알 오브젝트들은 비활성화 상태로 둔다.
        target.gameObject.SetActive(false);
        
        // 총알 오브젝트 정보를 PooledBehaviour 클래스의 target에 저장한다.
        return target;
    }
}
