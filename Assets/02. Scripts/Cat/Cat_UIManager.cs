using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Cat Intro에서 UI 상호작용을 위한 스크립트
namespace Cat
{
    public class Cat_UIManager : MonoBehaviour
    {
        public GameObject Play_Obj;
        public GameObject Intro_Obj;
        
        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        private void Start()
        {
            // 버튼 오브젝트에 스크립트를 통한 OnClick() 추가
            startButton.onClick.AddListener(OnStartButton);
        }
        
        public void OnStartButton()
        {
            if (inputField.text.Length > 0)
            {
                Debug.Log("입력한 텍스트 없음");
                return;
            }
            Play_Obj.SetActive(true);
            Intro_Obj.SetActive(false);
            Debug.Log($"{nameTextUI} 입력");
            nameTextUI.text = inputField.text;
        }
    }

}
