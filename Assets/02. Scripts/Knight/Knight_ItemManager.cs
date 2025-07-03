using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Knight_ItemManager : MonoBehaviour
{
    public GameObject inventoryUi;
    public Button inventoryButton;
    
    [SerializeField] private GameObject[] items;
    [SerializeField] private Transform slotGroup;
    
    public Knight_ItemSlot[] slots;

    private void Start()
    {
        // 자신과 자식 중에서 "Knight_ItemSlot" Component가 있는 대상을 모두 가져오는 기능
        slots = slotGroup.GetComponentsInChildren<Knight_ItemSlot>(true); // 비활성화 된 오브젝트도 참조
        inventoryButton.onClick.AddListener(OnInventory);
    }

    public void DropItem(Vector3 dropPos)
    {
        // 랜덤 인덱스 설정
        var randomIndex = Random.Range(0, items.Length); 

        // 아이템 생성
        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity); 
        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        
        // 랜덤한 방향으로 힘을 가하는 기능
        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);
        
        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item)
    {
        // 인벤토리에 넣는 기능
        foreach (var slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.AddItem(item);
                break;
            }
        }
    }

    private void OnInventory()
    {
        // activeSelf 현재 active 상태 
        inventoryUi.SetActive(!inventoryUi.activeSelf);
    }
}
