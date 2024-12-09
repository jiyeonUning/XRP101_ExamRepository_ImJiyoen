using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /*
    �־��� ������Ʈ�� ������ ����� �����ϰ��� ������ ������Ʈ�̴�.

    FPS ���� ����
    1. ���� ��, ���콺 Ŀ���� ��Ȱ��ȭ�Ǹ� ���콺 ȸ������ �÷��̾��� �þ߰� ȸ���Ѵ�.
    2. ���� �ٶ󺸰� �ִ� ���� �������� W, A, S, D�� ��, ��, ��, �� �̵��� �����Ѵ�
    3. ���콺 ��Ŭ�� ��, �þ� ���� �������� ���̸� �߻��ϰ� ����ĳ��Ʈ�� ����� ���� �̸��� �ֿܼ� �α׷� ����Ѵ�.
    4. �� ��ɵ��� �����ϰ��� �� �� ���õ� ������Ʈ���� �߻��ϴ� �������� ��� �����ϰ� �ùٸ��� �����ϵ��� �ҽ��ڵ带 �����Ͻÿ�. 
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

        // ���� : _followTarget - transform
        // ���� : transform - _followTarget
        // �� �����ߴ°�? : transform���� �ٲ���� �� ������Ʈ�� Ÿ��, �� �÷��̾ �ƴ� ī�޶��̱� ����
        transform.SetPositionAndRotation(
            _followTarget.position,
            _followTarget.rotation
            );
    }
}
