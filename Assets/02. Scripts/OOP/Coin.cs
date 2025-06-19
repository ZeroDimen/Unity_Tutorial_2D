using UnityEngine;

public class Coin : MonoBehaviour, IItem
{
    private Inventory inventory;

    public enum Cointype
    {
        Gold,
        Box
    }

    public Cointype coinType;

    public float price;


    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>(); // 씬에 있는 오브젝트를 찾아서 할당하는 방법
        Obj = this.gameObject;
    }

    public void OnMouseDown()
    {
        Get();
    }

    public GameObject Obj { get; set; }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득 했습니다");
        inventory.AddItem(this); // 암시적 형변환
        gameObject.SetActive(false);
    }
}