using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /* ���� 03
       �־��� ������Ʈ�� ������ ����� �����ϰ��� ������ ������Ʈ�̴�.

    1. Turret
    Trigger ���� ���� �÷��̾ ������ ��, 1.5�ʿ� �� �� �� �÷��̾ �ٶ󺸸� �Ѿ��� �߻��Ѵ�.
    Trigger ���� �ٱ����� �÷��̾ ������, �߻縦 �����Ѵ�.
    ������Ʈ Ǯ�� ����� �Ѿ��� �����Ѵ�.

    2. Bullet
    20 ��ŭ�� ���� ������, ������ ���� �߻�ȴ�.
    �߻� �� 5��  ��� �� ��Ȱ��ȭ ó�� �ȴ�.
    �÷��̾ �������� ���, 2�� �������� �ش�.

    3. Player
    �Ѿ˰� �浹���� ��, �������� �Դ´�.
    ü���� 0 ���ϰ� �� ���, ȿ������ ����ϸ� ��Ȱ��ȭ �ȴ�.
    �÷��̾��� �̵��� �� �並 ����� �̵��ϵ��� �Ѵ�. (= �̵� ���� ����.)


    �� ��ɵ��� �����ϰ��� �� ��, ���õ� ������Ʈ���� �߻��ϴ� �������� ��� �����ϰ�, �ùٸ��� �����ϵ��� �ҽ��ڵ带 �����ϼ���.
     
     */


    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; } // �÷��̾��� HP

    private AudioSource _audio;         // �÷��̾� ��� �� ��µǴ� �������

    private void Awake()
    {
        // ������ �÷��� �� ��, ����� �ҽ� ������Ʈ�� �����Ѵ�.
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        // �÷��̾ �Ѿ˿� ����� ��(���� ������ Bullet���� ����), HP�� ������ ��ŭ �����Ѵ�.
        Hp -= damage;

        // �÷��̾��� ü���� 0 ������ ��, Die�Լ��� ȣ���Ѵ�.
        // �ش� ���ǹ����� <= �� ����Ͽ����Ƿ�, �÷��̾��� ü���� 0�� ��쿡�� if�� ������ ���� ���� �� �ִ�.
        // �ش� ���� �÷��� �� Ȯ���� ����
        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // �÷��̾ ����� ��, ����� �ҽ��� ����ϰ�, �÷��̾ ��Ȱ��ȭ �Ѵ�.
        _audio.Play();
        gameObject.SetActive(false);
    }

    public void Play()
    {
        // ���� ���� -> �Ҹ� ����ϴ� ������ �ִٰ� ����

        // ����� Ŭ���� ���� ���°� �ƴ� ��,
        if (!_audio.loop)
        {
            // �ش� ������� ���� ���� ������Ʈ�� �����Ѵ�.
            Destroy(gameObject, _audio.clip.length);
        }
    }
}
