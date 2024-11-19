using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status; // �÷��̾� �������ͽ� ����

    private void Awake()
    {
        // �������ͽ��� Awake���� ���� �� �����Ѵ�.
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        // �� ������Ʈ ���� �÷��̾� �̵� �Լ��� �����Ѵ�.
        MovePosition();
    }

    private void MovePosition()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        // �÷��̾�� �������� ���ٸ�, �������� �ʴ´�.
        if (direction == Vector3.zero) return;
        
        // Translate�� ���� �÷��̾ �����̵��� �Ѵ�.
        // �밢������ �̵� �� 1.414�� ���� �����̰� �Ǵ� ������ ���,
        // �ԷµǴ� Vector3�� ���� x, z�� �� ���� �Ǳ� ������, ���� ���ư����� ������ �¹��� �ӵ��� �����ϴ� ������ ���δ�.
        // ���� �ӵ��� ��� �����̵� �����ϰ� �����ϱ� ����, direction�� ����ȭ �ϴ� normalized�� �ڿ� �����δ�.
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized);
    }
}
