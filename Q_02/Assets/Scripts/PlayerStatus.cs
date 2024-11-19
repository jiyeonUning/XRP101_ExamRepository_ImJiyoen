using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    /* 문제 02
     
       주어진 프로젝트 내에서 제공된 스크립트는 다음의 책임을 가진다.
    1. PalyerStatus   : 플레이어 캐릭터가 가지는 기본 능력치를 보관한다. 객체 생성 시 초기화 된다.
    2. PlayerMovement : 유저의 입력을 받고, 플레이어 캐릭터를 이동시킨다.
    
    문제 사항 :
    1. 유니티 에디터에서 Run 실행 시, 윈도우에서는 stack Overflow가 발생하며 MacOS의 유니티에서는 에디터가 강제종료된다.
    2. 플레이어 캐릭터가 X, Z축의 입력을 동시 입력 받아 대각선으로 이동할 때, 하나의 축 기준으로 움직일 때 보다 약 1.414배 빠르게 움직인다.
     
    두 문제가 발생한 원인과 해결 방법을 모두 서술하시오.   */

    /* 수정 진행 이전 시점에서, 유니티 실행 시 콘솔창에 출력되는 오류 :
     
     StackOverflowException: The requested operation caused a stack overflow.
     PlayerStatus.set_MoveSpeed (System.Single value) (at Assets/Scripts/PlayerStatus.cs:18)
     PlayerStatus.set_MoveSpeed (System.Single value) (at Assets/Scripts/PlayerStatus.cs:18)

     . . . ( 중략 ) . . .

     PlayerStatus.set_MoveSpeed (System.<message truncated>    */


    // get의 반환형이 자기 자신이므로, set에서 설정된 값으로 자기자신이 설정되어 있는데, 동시에 get에서도 본인을 반환형을 두고 있어 
    // 다시 set에서 값을 재설정하기 위해 다시 호출하는 과정을 반복하게 되어, 오버플로우가 일어나는 것으로 확인된다.

    // 해결 방안 : 반환할 자료형을 따로 두어서, 해당 값을 읽어들이고 반환하도록 한다.
    public float MoveSpeed
    {
        get => MoveSpeed;
        private set => MoveSpeed = value; // 문제가 발생하는 부분
    }

    private void Awake()
    {
        // 게임 플레이 실행 시, MoveSpeed의 값을 5f로 설정한다.
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
