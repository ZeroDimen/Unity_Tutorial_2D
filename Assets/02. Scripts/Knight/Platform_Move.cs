using UnityEngine;

// 플랫폼을 좌우로 움직이게 하기 위한 스크립트
public class Platform_Move : MonoBehaviour
{
    public enum MoveType {Horizontal, Vertical}
    public MoveType moveType;
    
    [SerializeField]
    private float theta;
    [SerializeField]
    private float power = 0.1f;
    [SerializeField]
    private float speed = 1f;

    private Vector3 initPos;

    private void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        theta += Time.deltaTime * speed;
        
        if(moveType == MoveType.Horizontal)
            transform.position = new Vector3(initPos.x + power * Mathf.Sin(theta), initPos.y , initPos.z);
        else if (moveType == MoveType.Vertical)
            transform.position = new Vector3(initPos.x , initPos.y + power * Mathf.Sin(theta), initPos.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플랫폼에 닿았으면 계층구조에 대입하여 플랫폼과 같이 이동할 수 있도록 함
            collision.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플랫폼에서 벗어났을 경우 계층구조를 해제하여 플랫폼과 별개로 이동할 수 있도록 함
            collision.transform.SetParent(null);
        }
    }
}
