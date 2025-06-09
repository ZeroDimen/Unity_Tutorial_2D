using System;
using UnityEngine;

// Switch를 사용한 Loop문을 확인하는 스크립트
public class Study_SwitchLoop : MonoBehaviour
{
    public enum CalculationType // 열거형 선언
    {
        Plus,
        Minus,
        Multiply,
        Divide
    }
    public CalculationType calculationType; // Plus가 자동으로 잡힘

    public int input1, input2, result;

    private void Start()
    {
       Debug.Log($"Result: {Calculation()}");
    }

    private int Calculation()
    {
        switch (calculationType)
        {
            case CalculationType.Plus:
                result = input1 + input2;
                break;
            case CalculationType.Minus:
                result = input1 - input2;
                break;
            case CalculationType.Multiply:
                result = input1 * input2;
                break;
            case CalculationType.Divide:
                result = input1 / input2;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        return result;
    }
}
