using UnityEngine;

// 카메라가 Player를 따라가게 하는 스크립트
public class Knight_CameraFollow : MonoBehaviour
{
    private Transform traget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed = 5f;
    
    [SerializeField] private Vector2 minBound;
    [SerializeField] private Vector2 maxBound;
    private void Start()
    {
        traget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate() 
    {
        Vector3 destnation = traget.position + offset;
        
        // Vector3.Lerp(현재위치, 타겟위치, 비율)
        Vector3 smoothpos = Vector3.Lerp(transform.position, destnation, smoothSpeed * Time.deltaTime);
        
        smoothpos.x = Mathf.Clamp(smoothpos.x, minBound.x, maxBound.x);
        smoothpos.y = Mathf.Clamp(smoothpos.y, minBound.y, maxBound.y);
        
        transform.position = smoothpos;
    }
}
