using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �������� ����� ������ Vector3 ��
    // set, �� �� ������ private�� ��Ȳ�̹Ƿ�, set�� �����ϵ��� �ٲ��־���.
    public Vector3 SetPoint { get; set; }

    public void SetPosition()
    {
        // ť�� ������Ʈ�� ��ġ�� SetPoint�� �����Ѵ�.
        transform.position = SetPoint;
    }
}
