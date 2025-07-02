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

    public void get()
    {
        gameObject.SetActive(false);
        Inventory.GetItem(this);
    }

    public void Use()
    {
        Debug.Log("Hp Heart Use");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            get();
        }
    }
}
