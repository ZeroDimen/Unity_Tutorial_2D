
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// 무작위로 Array, List값의 순서를 바꾸는 스크립트
public class LottoGenerator : MonoBehaviour
{
    public int shuffleCount = 0;
    public float shuffleSpeed = 0.02f;
    
    public int[] intArray = new int[10]; // 배열은 미리 만들어 놓는 방식
    public List<int> intList = new List<int>(); // 필요할 때마다 추가 / 삭제 가능한 방식

    public TextMeshProUGUI[] rot_number;

    public Button suffleButton;
    
    private void Start()
    {
        List_Init();
        OnShuffle();
    }

    public void OnShuffle()
    {
        // StartCoroutine(ArrayShuffle());
        
        List_Init();
        StartCoroutine(ListShuffle());
    }

    public void List_Init()
    {
        suffleButton.interactable = false;
        intList.Clear();
        for (int i = 0; i < 45; i++) // List에 1 ~ 45까지 추가
        {
            intList.Add(i + 1);
        }
    }

    private IEnumerator ArrayShuffle() // Array를 무작위로 섞는 방법
    {
        for (int i = 0; i < shuffleCount; i++)
        {
            int randomInt_A = Random.Range(0, intArray.Length);
            int randomInt_B = Random.Range(0, intArray.Length);
        
            var temp = intArray[randomInt_A];
            intArray[randomInt_A] = intArray[randomInt_B];
            intArray[randomInt_B] = temp;
            
            yield return new WaitForSeconds(shuffleSpeed);
        }
    }
    
    private IEnumerator ListShuffle() // List를 무작위로 섞는 방법
    {
        for (int i = 0; i < shuffleCount; i++)
        {
            int randomInt_A = Random.Range(0, intList.Count);
            int randomInt_B = Random.Range(0, intList.Count);
        
            var temp = intList[randomInt_A];
            intList[randomInt_A] = intList[randomInt_B];
            intList[randomInt_B] = temp;
            
            for (int j = 0; j < 7; j++)
            {
                rot_number[j].text = intList[j].ToString();
            }
            
            yield return new WaitForSeconds(shuffleSpeed);
        }

        int rot_Number_Bonus = intList[intList.Count - 1];
        intList.Remove(intList.Count - 1);
        
        List<int> resultList = new List<int>();
        for (int i = 0; i < 6; i++)
        {
            resultList.Add(intList[i]);
        }
        
        resultList.Sort();
        
        for (int i = 0; i < resultList.Count; i++)
        {
            rot_number[i].text = resultList[i].ToString();
        }
        rot_number[rot_number.Length - 1].text = rot_Number_Bonus.ToString();
        
        Debug.Log($"이번 주 로또 번호 : {resultList[0]}, {resultList[1]}, {resultList[2]}, {resultList[3]}, {resultList[4]}, {resultList[5]} 보너스 넘버 : {rot_Number_Bonus}");
        suffleButton.interactable = true;
    }
}
