using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /*
    주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

    FPS 조작 구현
    1. 실행 시, 마우스 커서가 비활성화되며 마우스 회전으로 플레이어의 시야가 회전한다.
    2. 현재 바라보고 있는 방향 기준으로 W, A, S, D로 전, 후, 좌, 우 이동을 수행한다
    3. 마우스 좌클릭 시, 시야 정면 방향으로 레이를 발사하고 레이캐스트에 검출된 적의 이름을 콘솔에 로그로 출력한다.
    4. 위 기능들을 구현하고자 할 때 제시된 프로젝트에서 발생하는 문제들을 모두 서술하고 올바르게 동작하도록 소스코드를 개선하시오. 
     */


    private bool _hasFollowTarget;
    private Transform _followTarget;
    public Transform FollowTarget
    {
        get => _followTarget;
        set
        {
            _followTarget = value;
            if (_followTarget != null) _hasFollowTarget = true;
            else _hasFollowTarget = false;
        }
    }

    private void LateUpdate() => SetTransform();

    private void SetTransform()
    {
        if (!_hasFollowTarget) return;

        // 원본 : _followTarget - transform
        // 수정 : transform - _followTarget
        // 왜 수정했는가? : transform값을 바꿔줘야 할 오브젝트는 타겟, 즉 플레이어가 아닌 카메라이기 때문
        transform.SetPositionAndRotation(
            _followTarget.position,
            _followTarget.rotation
            );
    }
}
