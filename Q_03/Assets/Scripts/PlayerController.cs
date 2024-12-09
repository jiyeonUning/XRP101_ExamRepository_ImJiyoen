using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* 문제 03
       주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

    1. Turret
    Trigger 범위 내로 플레이어가 들어왔을 때, 1.5초에 한 번 씩 플레이어를 바라보며 총알을 발사한다.
    Trigger 범위 바깥으로 플레이어가 나가면, 발사를 중지한다.
    오브젝트 풀을 사용해 총알을 관리한다.

    2. Bullet
    20 만큼의 힘을 가지고, 전바을 향해 발사된다.
    발사 후 5초  경과 시 비활성화 처리 된다.
    플레이어를 가격했을 경우, 2의 데미지를 준다.

    3. Player
    총알과 충돌했을 때, 데미지를 입는다.
    체력이 0 이하가 될 경우, 효과음을 재생하며 비활성화 된다.
    플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다. (= 이동 구현 없음.)


    위 기능들을 구현하고자 할 때, 제시된 프로젝트에서 발생하는 문제들을 모두 서술하고, 올바르게 동작하도록 소스코드를 개선하세요.
     
     */


    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; } // 플레이어의 HP

    private AudioSource _audio;         // 플레이어 사망 시 출력되는 오디오음

    private void Awake()
    {
        // 게임이 플레이 될 때, 오디오 소스 컴포넌트를 참조한다.
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        // 플레이어가 총알에 닿았을 때(닿음 판정은 Bullet에서 구현), HP는 데미지 만큼 감소한다.
        Hp -= damage;

        // 플레이어의 체력이 0 이하일 때, Die함수를 호출한다.
        // 해당 조건문에서 <= 를 사용하였으므로, 플레이어의 체력이 0일 경우에도 if문 실행이 되지 않을 수 있다.
        // 해당 사항 플레이 시 확인할 예정
        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // 플레이어가 사망할 때, 오디오 소스를 재생하고, 플레이어를 비활성화 한다.
        _audio.Play();
        gameObject.SetActive(false);
    }

    public void Play()
    {
        // 설정 지정 -> 소리 재생하는 로직이 있다고 가정

        // 오디오 클립이 루프 상태가 아닐 때,
        if (!_audio.loop)
        {
            // 해당 오디오를 가진 게임 오브젝트를 삭제한다.
            Destroy(gameObject, _audio.clip.length);
        }
    }
}
