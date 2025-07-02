using UnityEngine;

public interface IItemObject
{
    Knight_ItemManager Inventory {get; set;}
    GameObject Object { get; set; }
    string ItemName { get; set; }
    Sprite Icon { get; set; }

    void get();
    void Use();
}