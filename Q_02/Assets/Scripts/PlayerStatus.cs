using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    /* ���� 02
     
       �־��� ������Ʈ ������ ������ ��ũ��Ʈ�� ������ å���� ������.
    1. PalyerStatus   : �÷��̾� ĳ���Ͱ� ������ �⺻ �ɷ�ġ�� �����Ѵ�. ��ü ���� �� �ʱ�ȭ �ȴ�.
    2. PlayerMovement : ������ �Է��� �ް�, �÷��̾� ĳ���͸� �̵���Ų��.
    
    ���� ���� :
    1. ����Ƽ �����Ϳ��� Run ���� ��, �����쿡���� stack Overflow�� �߻��ϸ� MacOS�� ����Ƽ������ �����Ͱ� ��������ȴ�.
    2. �÷��̾� ĳ���Ͱ� X, Z���� �Է��� ���� �Է� �޾� �밢������ �̵��� ��, �ϳ��� �� �������� ������ �� ���� �� 1.414�� ������ �����δ�.
     
    �� ������ �߻��� ���ΰ� �ذ� ����� ��� �����Ͻÿ�.   */

    /* ���� ���� ���� ��������, ����Ƽ ���� �� �ܼ�â�� ��µǴ� ���� :
     
     StackOverflowException: The requested operation caused a stack overflow.
     PlayerStatus.set_MoveSpeed (System.Single value) (at Assets/Scripts/PlayerStatus.cs:18)
     PlayerStatus.set_MoveSpeed (System.Single value) (at Assets/Scripts/PlayerStatus.cs:18)

     . . . ( �߷� ) . . .

     PlayerStatus.set_MoveSpeed (System.<message truncated>    */


    // get�� ��ȯ���� �ڱ� �ڽ��̹Ƿ�, set���� ������ ������ �ڱ��ڽ��� �����Ǿ� �ִµ�, ���ÿ� get������ ������ ��ȯ���� �ΰ� �־� 
    // �ٽ� set���� ���� �缳���ϱ� ���� �ٽ� ȣ���ϴ� ������ �ݺ��ϰ� �Ǿ�, �����÷ο찡 �Ͼ�� ������ Ȯ�εȴ�.

    // �ذ� ��� : ��ȯ�� �ڷ����� ���� �ξ, �ش� ���� �о���̰� ��ȯ�ϵ��� �Ѵ�.
    public float MoveSpeed
    {
        get => MoveSpeed;
        private set => MoveSpeed = value; // ������ �߻��ϴ� �κ�
    }

    private void Awake()
    {
        // ���� �÷��� ���� ��, MoveSpeed�� ���� 5f�� �����Ѵ�.
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
