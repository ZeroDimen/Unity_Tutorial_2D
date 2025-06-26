using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Portal_Pad : MonoBehaviour
{
    private string inputNum;
    public TextMeshProUGUI tpString;
    
    [SerializeField]
    private RawImage cctvImage;

    [SerializeField] private GameObject[] Zone_Number;

    private bool isWarp;
    private Camera camera;
    public Transform Player; // 개선 해야할지도
    public static string Zone_name;
    private int currentZone;
    
    public void Start()
    {
        inputNum = "";
        isWarp = false;
        Get_Zone_Number();
        Get_CCTV(currentZone);
        tpString.text = $"Teleport \n Zone {currentZone} -> Zone ";
    }

    private void Get_Zone_Number()
    {
        string str_Zone = Zone_name.Replace("Zone_", "");
        currentZone = int.Parse(str_Zone);
        bool result = int.TryParse(str_Zone , out currentZone);
        if (result == false)
        {
            Debug.Log($"Portal_Pad Err : input {Zone_name}");
        }
    }

    private void Get_CCTV(int Zone_Num)
    {
        if (Zone_Num <= Zone_Number.Length)
        {
            camera = Zone_Number[Zone_Num].GetComponentInChildren<Camera>();;
            cctvImage.texture = camera.targetTexture;
            isWarp = true;
        }
        else
        {
            Debug.Log("Zone Number out of range");
        }
    }

    private void CCTV(int touchNum)
    {
        if (touchNum <= Zone_Number.Length)
        {
            camera = Zone_Number[touchNum].GetComponentInChildren<Camera>();;
            
            if (!isWarp) // 같은 번호 2번 입력시 위치이동
            {
                cctvImage.texture = camera.targetTexture;
                isWarp = true;
            }
            else
            {
                Player.position =  camera.transform.position;
            }
        }
        else
        {
            Debug.Log("CCTV ERROR");
            isWarp = false;
        }
    }

    private void TouchnumPad(string numString) // numPad에서 버튼 입력시 호출 되는 함수
    {
        if (numString == "Enter") // Enter 버튼 입력시
        {
            // Get_CCTV();
        }
        else if (numString == "Delete") // Delete 버튼 입력시
        {
            inputNum = "";
        }
        else
        {
            inputNum += numString;
            if (inputNum == "0")
            {
                inputNum = "";
            }
        }
        
        tpString.text = $"Teleport \n Zone {currentZone} -> Zone {inputNum}";
    }
}

