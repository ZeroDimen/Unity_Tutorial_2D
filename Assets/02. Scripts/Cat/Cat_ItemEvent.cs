using System;
using UnityEngine;
using Random = UnityEngine.Random;


// 오브젝트를 움직이고 카메라 밖으로 나갈시 위치를 초기화 하여 반복되는 이미지를 만들기 위한 스크립트
public class Cat_ItemEvent : MonoBehaviour
{
    public enum ItemMixture {Pipe, Fruit, Both}
    public ItemMixture itemMixture;
    
    public GameObject particle;
    public GameObject Pipe;
    public GameObject Fruit;
    
    public float Loop_Speed = 3f;
    public float ReturnPosX = 15f;
    public float Random_PosY;

    private void Start()
    {
        SetRandomSetting(transform.position.x);
    }

    private void Update()
    {
        Image_Loop_DeltaTime();
    }

    private void Image_Loop_DeltaTime() // Time.deltaTime 값의 오차로 이동할 타이밍에 오차가 생김
    {
        transform.position += Vector3.left * (Loop_Speed * Time.deltaTime);
        
        if (transform.position.x <= -ReturnPosX) // 오브젝트 x축 위치가 -ReturnPosX 이하일경우
        {
            SetRandomSetting(ReturnPosX);
        }
    }

    private void SetRandomSetting(float posX)
    {
        Random_PosY = Random.Range(-8f, - 3.5f);
        transform.position = new Vector3(posX, Random_PosY, 0f);

        itemMixture = (ItemMixture)Random.Range(0, 3);  // 형변환(Typecasting) int -> ItemMixture 명시적 형변환
        
        Pipe.SetActive(false);
        Fruit.SetActive(false);
        
        switch (itemMixture) // 3가지 조합중 무작위로 생성
        {
            case ItemMixture.Pipe:
                Pipe.SetActive(true);
                break;
            case ItemMixture.Fruit:
                Fruit.SetActive(true);
                break;
            case ItemMixture.Both:
                Pipe.SetActive(true);
                Fruit.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
