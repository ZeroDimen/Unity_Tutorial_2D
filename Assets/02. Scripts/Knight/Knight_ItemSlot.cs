using UnityEngine;
using UnityEngine.UI;

public class Knight_ItemSlot : MonoBehaviour
{
    private IItemObject item; // 슬롯에 들어올 아이템
    [SerializeField] private Image itemImage; // 먹은 아이템의 이미지가 들어갈 위치
    [SerializeField] private Button slotButton; // 아이템 Use()를 하기 위한 버튼

    public bool isEmpty = true;
    private void Awake() // 오브젝트에서 켜지는게 아니라 Awake가 실행되지않는 문제??
    {
        slotButton.onClick.AddListener(UseItem); 
    }

    private void OnEnable() // 오브젝트가 활성화 될 때마다가 1번씩 실행
    {
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = item.Icon;
        itemImage.SetNativeSize(); // 이미지의 사이즈 조정
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}
