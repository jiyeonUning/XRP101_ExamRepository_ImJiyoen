using UnityEngine;

public class CubeManager : MonoBehaviour
{
    /* ���� 01
     
          �־��� CubeMAnager ��ü�� ������ å���� ������.
       1. �ش� ��ü ���� ��, Cube �������� �ν��Ͻ��� �����Ѵ�.
       2. Cube �ν��Ͻ��� ��Ʈ�ѷ��� ������, ��ġ�� �����Ѵ�.
      
       ���õ� �ҽ��ڵ忡���� ť�� �ν��Ͻ��� ���� ��, �Ʒ� ��ǥ�� �̵���Ű�� ���� ��ǥ�� �Ͽ���.
       Vector3(3, 0, 3)
      
       ���õ� �ҽ��ڵ忡�� ������ �߻��ϴ� ������ ��� �����Ͻÿ�.  */

    /* ���� ���� ���� ��������, ����Ƽ ���� �� �ܼ�â�� ��µǴ� ���� : 
       NullReferenceException: Object reference not set to an instance of an object
       CubeManager.SetCubePosition (System.Single x, System.Single y, System.Single z) (at Assets/Scripts/CubeManager.cs:56)
       CubeManager.Awake () (at Assets/Scripts/CubeManager.cs:36)      */


    [SerializeField] private GameObject _cubePrefab; // ť�� ������ ������ ���� ���� ������Ʈ ����

    private CubeController _cubeController;          // ť�� ��Ʈ�ѷ� ����
    private Vector3 _cubeSetPoint;                   // �̵��� ��ġ�� �����Ͽ� ����ϱ� ���� ��ǥ��


    private void Awake()
    {
        // ť�� �Ŵ����� ������ �÷��� �� ��, �ش� �Լ��� ���� ť�긦 �����Ѵ�.
        CreateCube();
    }

    private void Start()
    {
        // ť�� �Ŵ����� Awake ���� �� �ش� �Լ��� ()���� ���߾� �����Ѵ�.
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        // ť�� ������Ʈ�� ��ġ�� �����ϴ� �Լ�.

        // _cubeSetPoint�� �� ����, ť�� ������Ʈ�� �̵��� ��ġ�� ��ǥ���� �Է¹޾� �����Ѵ�.
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;

        // �Է¹��� ��ǥ���� ����, ť�� ������Ʈ�� �̵��� �� �ִ� �Լ��� �����Ѵ�.
        _cubeController.SetPosition(_cubeSetPoint);
    }

    private void CreateCube()
    {
        // ť�� ������Ʈ�� �����ϴ� �Լ�.

        // Instantiate�� ť�� ������Ʈ�� �����԰� ���ÿ�, �ش� ������Ʈ�� �����Ѵ�.
        GameObject cube = Instantiate(_cubePrefab);
        // ������ ť�� ������Ʈ���� CubeController Ŭ������ �����Ͽ� �����Ѵ�.
        _cubeController = cube.GetComponent<CubeController>();

        // ť�� ��Ʈ�ѷ����� ��ü������ ������ Vector3���� ���� �����ϵ��� �Ͽ��� ������, �ش� �ڵ�� ������� �ʰ� �ȴ�.
         //_cubeController.SetPoint = _cubeSetPoint;
    }
}
