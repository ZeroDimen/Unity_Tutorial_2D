using System;
using UnityEngine;

public class Knight_HpHeart : MonoBehaviour, IItemObject
{
    public Knight_ItemManager Inventory { get; set; }
    public GameObject Object { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }

    private void Start()
    {
        Inventory = FindFirstObjectByType<Knight_ItemManager>();
        
        Object = this.gameObject;
        ItemName = this.gameObject.name;
        Icon = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public void Get()
    {
        gameObject.SetActive(false); // 아이템을 먹은 것 처럼 보여주기 위해 오브젝트 비활성화
        Inventory.GetItem(this); // 인벤토리에게 아이탬 획득을 알리는 기능
    }

    public void Use()
    {
        var knight = GameObject.FindGameObjectWithTag("Player");
        Debug.Log($"Use {ItemName}");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
