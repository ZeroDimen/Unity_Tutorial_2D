using UnityEngine;

// 오브젝트를 회전하는 스크립트
public class Study_LookAt : MonoBehaviour
{
    // public GameObject Target; 사용되는 값은 Transform이기때문에
    public Transform Target_Tf; // Transform 자료형이 더 효율적
    [SerializeField]
    private Transform Turret_Head;
    public GameObject BulletPrefab;
    public Transform[] firePos;
    private void Start()
    {
        // Study_GameObject에 있는 CreateMonster() 함수가 작동해야 작동하므로 Awake 함수에서 호출하도록 수정함
        Target_Tf = GameObject.FindGameObjectWithTag("Player").transform;  // "Player" 태그를 가진 오브젝트를 찾아 transform 대입
    }

    private void Update()
    {
        // transform.LookAt(Vector3 바라볼 좌표, Vector3 회전하는 방향);
        
        // LookAt: 어딜 봐야 할지 정해주는 함수 (최종 목표 회전 값 설정)
        // Rotate: 얼마나 더 돌아야 할지 정해주는 함수 (현재 회전 값에서 추가 회전)
        
        // this.gameObject.transform.GetChild(0).transform.LookAt(Target_Tf); // GetChild를 사용하여 Turret_Head에 접근
        Turret_Head.transform.LookAt(Target_Tf);

        if (Input.GetKeyDown(KeyCode.P)) // 키보드 P 키를 누르면 작동하는 조건문
        {
            // Instantiate(GameObject (생성대상), Vector3 (생성 위치), Quaternion (회전 상태))
            // GameObject _BulletPrefab =  Instantiate(BulletPrefab, firePos.position, firePos.rotation); // firePos에서 BulletPrefab을 생성하는 함수
            // Destroy(_BulletPrefab, 2f); // BulletPrefab을 2초 뒤에 파괴하는 기능

            for (int i = 0; i < firePos.Length; i++)
            {
                Destroy(Instantiate(BulletPrefab, firePos[i].position, firePos[i].rotation),2f); // firePos에서 BulletPrefab을 생성 및 2초 뒤에 파괴하는 기능
            }
        }
       
    }
}
