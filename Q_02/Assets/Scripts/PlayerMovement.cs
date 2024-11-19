using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status; // 플레이어 스테이터스 참조

    private void Awake()
    {
        // 스테이터스는 Awake에서 참조 후 진행한다.
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        // 매 업데이트 마다 플레이어 이동 함수를 실행한다.
        MovePosition();
    }

    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        // 플레이어에게 움직임이 없다면, 움직이지 않는다.
        if (direction == Vector3.zero) return;
        
        // Translate를 통해 플레이어가 움직이도록 한다.
        // 대각선으로 이동 시 1.414배 빨리 움직이게 되는 문제의 경우,
        // 입력되는 Vector3의 값이 x, z로 두 개가 되기 때문에, 각자 나아가려는 방향이 맞물려 속도가 증가하는 것으로 보인다.
        // 따라서 속도를 어느 방향이든 일정하게 유지하기 위해, direction을 정규화 하는 normalized를 뒤에 덧붙인다.
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized);
    }
}
