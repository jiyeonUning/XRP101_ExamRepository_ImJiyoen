using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �������� ����� ������ Vector3 ��
    public Vector3 SetPoint { get; private set; }

    public void SetPosition()
    {
        // ť�� ������Ʈ�� ��ġ�� SetPoint�� �����Ѵ�.
        transform.position = SetPoint;
    }
}
