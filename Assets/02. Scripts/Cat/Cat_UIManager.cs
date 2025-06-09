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

        // private void Start()
        // {
        //     // 버튼 오브젝트에 스크립트를 통한 OnClick() 추가
        //     startButton.onClick.AddListener(OnStartButton);
        // }

        private void FixedUpdate() // 빈칸 입력이나 기본입력을 방지하기 위함
        {
            // if (inputField.text is "" or "고양이 이름을 정해주세요")
            if (inputField.text == "" || inputField.text == "고양이 이름을 정해주세요")
            {
                startButton.interactable = false;
            }
            else
            {
                startButton.interactable = true;
            }
        }

        public void OnStartButton()
        {
            Play_Obj.SetActive(true);
            Intro_Obj.SetActive(false);
            nameTextUI.text = inputField.text;
        }
    }

}
