using System;
using System.Collections.Generic;
using UnityEngine;

// 형변환을 알아보기 위한 스크립트
public class Study_Casting : MonoBehaviour
{
    List<Monster> monsters = new List<Monster>();
    private void Start()
    {
        // casting();
        Str();
    }

    private void OOP()
    {
        Orc o = new Orc();
        Goblin g = new Goblin();
        
        // Down Casting 
        // 문제가 생길 가능성이 있음
        // ex) Monster가 가진 함수가 Orc 가 가지고 있지 않아 문제가 생길수 있음
        Monster m = new Monster();
        Orc o2 = (Orc)m;
        

        Debug.Log(o2);
        
        // Up Casting 
        // 명시적 형변환
        Monster m1 =(Monster) o;
        Monster m2 =(Monster) g;

        Orc o3 = m as Orc; // 성공시 형변환, 실패시 null
        bool isMonster = o is Monster; // true
        
        
        // 암시적 형변환
        monsters.Add(o);
        monsters.Add(g);
    }

    private void casting()
    {
        int number1 = 10;
        float number2 = 20.53f;

        // 명시적 형변환 (float -> int), 강제(데이터 소실의 가능성이 있음)
        number1 = (int)number2; // 버림처리 (20)
        Debug.Log(number1);
        
        // 수학적인 기능
        float number3 = MathF.Floor(number2);   // 내림
        float number4 = MathF.Ceiling(number2); // 올림
        float number5 = MathF.Round(number2);   // 반올림 
        
        string str1 = number1.ToString(); // 문자열 변환

        Debug.Log($"Floor : {number3}");
        Debug.Log($"Ceiling : {number4}");
        Debug.Log($"Round : {number5}");
        
        // 암시적 형변환 (int -> float)
        Vector3 vec = new Vector3(10, 20, 30); 
        // Vector3Int vecInt = new Vector3Int(10, 20, 30); 
    }

    private void Str()
    {
        string str1 = "123";
        string str2 = "456";

        Debug.Log("string : " + str1 + str2); // 123456
        int num1 = int.Parse(str1);
        int num2 = int.Parse(str2);


        Debug.Log("Int : " + num1 + num2); // 123456
        Debug.Log("Int : " + (num1 + num2)); // 579
        Debug.Log($"Int : {num1} + {num2}"); // 123 + 456
    }
}
