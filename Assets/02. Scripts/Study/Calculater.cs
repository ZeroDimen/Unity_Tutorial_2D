using UnityEngine;

// 반환 타입에 대해 알아보는 스크립트
namespace _02._Scripts
{
    public class Calculater : MonoBehaviour
    {
        public int A;
        public int B;

        private void Start()
        {
            // Add_Mathod();
            // Minus_Mathod();
            //Debug.Log($"Add : {Plus_Mathod(A, B)}");  반환 값이 없으므로 오류 발생
            Debug.Log($"Minus : {Minus_Mathod(A, B)}");

        }

        void Plus_Mathod(int _A , int _B)
        {
            int result = _A + _B;
            //return result; 반환 타입이 void 형이므로 int 타입 반환 불가
        }
        
        int Minus_Mathod(int _A, int _B)
        {
            int result =  _A - _B;
            return result;
        }
    }
}