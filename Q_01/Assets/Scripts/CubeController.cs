using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // 함수 자체에서 Vector3 값을 변경하여 사용하게 하였으므로, 해당 Vector3 값은 사용하지 않는다.
    // public Vector3 SetPoint { get; set; }

    public void SetPosition(Vector3 SetPoint)
    {
        // 큐브 오브젝트의 위치를 SetPoint로 설정한다.
        // + 외부에서 SetPoint 값을 변경 가능하도록 함수 내부에서 자체적으로 Vector3를 선언해 사용하였다.
        transform.position = SetPoint;
    }
}
