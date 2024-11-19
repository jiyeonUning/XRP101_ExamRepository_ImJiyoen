using UnityEngine;

public class CubeManager : MonoBehaviour
{
    /* 문제 01
     
          주어진 CubeMAnager 객체는 다음의 책임을 가진다.
       1. 해당 객체 생성 시, Cube 프리팹의 인스턴스를 생성한다.
       2. Cube 인스턴스의 컨트롤러를 참조해, 위치를 변경한다.
      
       제시된 소스코드에서는 큐브 인스턴스를 생성 후, 아래 좌표로 이동시키는 것을 목표로 하였다.
       Vector3(3, 0, 3)
      
       제시된 소스코드에서 문제가 발생하는 원인을 모두 서술하시오.  */

    /* 수정 진행 이전 시점에서, 유니티 실행 시 콘솔창에 출력되는 오류 : 
       NullReferenceException: Object reference not set to an instance of an object
       CubeManager.SetCubePosition (System.Single x, System.Single y, System.Single z) (at Assets/Scripts/CubeManager.cs:56)
       CubeManager.Awake () (at Assets/Scripts/CubeManager.cs:36)      */


    [SerializeField] private GameObject _cubePrefab; // 큐브 프리팹 생성을 위한 게임 오브젝트 참조

    private CubeController _cubeController;          // 큐브 컨트롤러 참조
    private Vector3 _cubeSetPoint;                   // 이동할 위치를 저장하여 사용하기 위한 좌표값


    private void Awake()
    {
        // 큐브 매니저는 게임이 플레이 될 때, 해당 함수를 통해 큐브를 생성한다.
        CreateCube();
    }

    private void Start()
    {
        // 큐브 매니저는 Awake 실행 후 해당 함수를 ()값에 맞추어 실행한다.
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        // 큐브 오브젝트의 위치를 설정하는 함수.

        // _cubeSetPoint의 각 값에, 큐브 오브젝트가 이동할 위치의 좌표값을 입력받아 기입한다.
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;

        // 입력받은 좌표값에 따라, 큐브 오브젝트를 이동할 수 있는 함수를 실행한다.
        _cubeController.SetPosition(_cubeSetPoint);
    }

    private void CreateCube()
    {
        // 큐브 오브젝트를 생성하는 함수.

        // Instantiate로 큐브 오브젝트를 생성함과 동시에, 해당 오브젝트를 참조한다.
        GameObject cube = Instantiate(_cubePrefab);
        // 생성된 큐브 오브젝트에서 CubeController 클래스를 참조하여 저장한다.
        _cubeController = cube.GetComponent<CubeController>();

        // 큐브 컨트롤러에서 자체적으로 본인의 Vector3값을 변경 가능하도록 하였기 때문에, 해당 코드는 사용하지 않게 된다.
         //_cubeController.SetPoint = _cubeSetPoint;
    }
}
