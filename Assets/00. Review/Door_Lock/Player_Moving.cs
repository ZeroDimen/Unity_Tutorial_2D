using UnityEngine;

public class Player_Moving : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h,0,v);
        Vector3 normaldir = dir.normalized;
        // this.gameObject.transform.localPosition += normaldir * (moveSpeed * Time.deltaTime);
        this.gameObject.transform.Translate(Vector3.forward);
        
        // this.gameObject.transform.LookAt(transform.localPosition + normaldir);
        // this.gameObject.transform.Translate(Vector3.right * (h * Time.deltaTime));
    }
}
