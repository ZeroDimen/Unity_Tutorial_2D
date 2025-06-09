using UnityEngine;

// Foreach를 사용한 Loop문을 확인하는 스크립트
public class Study_Foreach : MonoBehaviour
{
    public string[] persons = new string[5]
    {
        "민수","철수","영희","동수","존"
    };

    public string Findname;
    void Start()
    {
        FindName(Findname);
    }

    private void FindName(string name)
    {
        bool isFind = false;
        foreach (var person in persons) // var: 타입 추론형
        {
            if (person == name)
            {
                isFind = true;
                Debug.Log($"{name} is found");
            }
        }

        if (!isFind)
        {
            Debug.Log($"{name} is not found");
        }
    }
 
}
