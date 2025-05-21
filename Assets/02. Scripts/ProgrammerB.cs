using UnityEngine;
using DevA;

// ProgrammerB 스크립트에서 ProgrammerA 스크립트의 변수에 접근하는 스크립트
public class ProgrammerB : MonoBehaviour
{
    // 클래스를 활용해서 생성된 Object
    // public DevA.ProgrammerA pA = new ProgrammerA();
    
    // 유니티 Scene Object에 스크립트로 들어가있으면 객체화 되어 new ProgrammerA();와 동일한 처리가 작동.
    public ProgrammerA pA;

    private void Start()
    {
        // pA.number1 = 10;
        pA.number2 = 20; // public 선언된 number2 변수만 다른 클래스에서 참조 가능.
        // pA.number3 = 30;
        // pA.number4 = 40;
        // pA.number5 = 50;
    }
}
