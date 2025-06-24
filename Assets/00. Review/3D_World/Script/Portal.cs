using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject numPad_Canvas;

    private void Start()
    {
        numPad_Canvas = GameObject.Find("TPManager").gameObject.transform.GetChild(0).gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        // if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("Player")) // 서로 호출시간이 달라서 반응이 늦음 다른방법이 필요함
        if (other.CompareTag("Player"))
        {
            Player_MouseLook.ViewCursor(true);
            numPad_Canvas.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player_MouseLook.ViewCursor(false);
            numPad_Canvas.SetActive(false);
        }
    }
    
}
