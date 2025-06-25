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
            Debug.Log(Portal_Pad.Zone_name);
            string currentZone = this.gameObject.transform.parent.name;
            numPad_Canvas.SetActive(true);

            Debug.Log(this.gameObject.transform.parent.name);
            Portal_Pad.Zone_name = currentZone;
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
