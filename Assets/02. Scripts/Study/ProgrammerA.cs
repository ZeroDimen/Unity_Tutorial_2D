using UnityEngine;

namespace DevA
{
    // ProgrammerB 스크립트에서 ProgrammerA 스크립트의 변수에 접근하는 스크립트
    public class ProgrammerA : MonoBehaviour
    {
        int number1;
        public int number2; // public 선언된 number2 변수만 다른 클래스에서 참조 가능.
        private int number3;
    
        [SerializeField] int number4;
        [SerializeField] private int number5;
    }

}
