using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // �Լ� ��ü���� Vector3 ���� �����Ͽ� ����ϰ� �Ͽ����Ƿ�, �ش� Vector3 ���� ������� �ʴ´�.
    // public Vector3 SetPoint { get; set; }

    public void SetPosition(Vector3 SetPoint)
    {
        // ť�� ������Ʈ�� ��ġ�� SetPoint�� �����Ѵ�.
        // + �ܺο��� SetPoint ���� ���� �����ϵ��� �Լ� ���ο��� ��ü������ Vector3�� ������ ����Ͽ���.
        transform.position = SetPoint;
    }
}
