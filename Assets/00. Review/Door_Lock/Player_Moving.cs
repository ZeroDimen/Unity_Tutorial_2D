using UnityEngine;

public class Player_Moving : MonoBehaviour
{
    public float moveSpeed;
    void FixedUpdate()
    {
        float moveX  = Input.GetAxis("Horizontal");
        float moveY  = Input.GetAxis("Vertical");

        Vector3 movement = (transform.forward * moveY + transform.right * moveX).normalized;
        Vector3 normaldir = movement.normalized;
        
        transform.position += normaldir * (moveSpeed * Time.deltaTime);
    }
}
