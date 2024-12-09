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

        // 수정 전 호출되지 않았던 이유 : 레이어마스크 대상자가 설정되어 있지 않았기 때문
        // 해결 방안 : 레이어마스크를 설정

        // 추가적인 오류 : 일부 Enrmy가 인식되지 않음
        //   확인된 오류 : Vector3를 기준으로 ray 발사를 하기 때문에, 레이저 방향이 월드 좌표 방향으로 앞방향, 즉 z방향 한정이었음 
        //     해결 방안 : 입력된 origin을 기준으로 앞방향으로 발사되도록, forward가 될 transform을 origin으로 수정한다.
        Ray ray = new(origin.position, origin.forward);
        RaycastHit hit;

  
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
