using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{

    /*
     주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

     01. Main Scene
     실행 시, Start 버튼을 누르면 게임매니저를 통해 게임 씬이 로드된다.

     02. Game Scene
     Go to Main을 누르면 메인 씬으로 이동한다
     +버튼을 누르면 큐브 오브젝트의 회전 속도가 증가한다
     -버튼을 누르면 큐브 오브젝트의 회전 속도가 감소한다 (-가 될 경우 역방향으로 회전한다)
     Popup 버튼을 누르면 게임 오브젝트가 정지(큐브의 회전이 정지)하며, Popup창을 출력한다. 이 때 출력된 팝업창은 2초 후 자동으로 닫힌다.

     공통 사항
     게임 실행 중 씬 전환 시에도 큐브 오브젝트의 회전 속도는 저장되어 있어야 한다.
     위 기능들을 구현하고자 할 때 제시된 프로젝트에서 발생하는 문제들을 모두 서술하고 올바르게 동작하도록 소스코드를 개선하시오.  
     */


    [SerializeField] public float Score { get; set; }

    private void Awake()
    {
        SingletonInit();
        Score = 0.1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Run()
    {
        Time.timeScale = 1f;
    }

    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
