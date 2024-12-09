using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{

    /*
     �־��� ������Ʈ�� ������ ����� �����ϰ��� ������ ������Ʈ�̴�.

     01. Main Scene
     ���� ��, Start ��ư�� ������ ���ӸŴ����� ���� ���� ���� �ε�ȴ�.

     02. Game Scene
     Go to Main�� ������ ���� ������ �̵��Ѵ�
     +��ư�� ������ ť�� ������Ʈ�� ȸ�� �ӵ��� �����Ѵ�
     -��ư�� ������ ť�� ������Ʈ�� ȸ�� �ӵ��� �����Ѵ� (-�� �� ��� ���������� ȸ���Ѵ�)
     Popup ��ư�� ������ ���� ������Ʈ�� ����(ť���� ȸ���� ����)�ϸ�, Popupâ�� ����Ѵ�. �� �� ��µ� �˾�â�� 2�� �� �ڵ����� ������.

     ���� ����
     ���� ���� �� �� ��ȯ �ÿ��� ť�� ������Ʈ�� ȸ�� �ӵ��� ����Ǿ� �־�� �Ѵ�.
     �� ��ɵ��� �����ϰ��� �� �� ���õ� ������Ʈ���� �߻��ϴ� �������� ��� �����ϰ� �ùٸ��� �����ϵ��� �ҽ��ڵ带 �����Ͻÿ�.  
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
