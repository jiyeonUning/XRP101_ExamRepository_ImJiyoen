using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // 전역에서 사용이 가능한 Vector3 값
    public Vector3 SetPoint { get; private set; }

    public void SetPosition()
    {
        // 큐브 오브젝트의 위치를 SetPoint로 설정한다.
        transform.position = SetPoint;
    }
}
