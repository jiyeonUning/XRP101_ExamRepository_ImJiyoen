using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;
    
    public void Fire(Transform origin)
    {

        // ���� �� ȣ����� �ʾҴ� ���� : ���̾��ũ ����ڰ� �����Ǿ� ���� �ʾұ� ����
        // �ذ� ��� : ���̾��ũ�� ����

        // �߰����� ���� : �Ϻ� Enrmy�� �νĵ��� ����
        //   Ȯ�ε� ���� : Vector3�� �������� ray �߻縦 �ϱ� ������, ������ ������ ���� ��ǥ �������� �չ���, �� z���� �����̾��� 
        //     �ذ� ��� : �Էµ� origin�� �������� �չ������� �߻�ǵ���, forward�� �� transform�� origin���� �����Ѵ�.
        Ray ray = new(origin.position, origin.forward);
        RaycastHit hit;

  
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
