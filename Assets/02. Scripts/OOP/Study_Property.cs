using UnityEngine;

// 변수를 캡슐화(Property)해보는 스크립트
public class Study_Property : MonoBehaviour
{
   public int number0 = 4; // 은식성을 위배한 필드
   private int number1 = 10; // 은닉성을 위배하지 않은 필드 
   
   // Number1 변수를 사용하면 외부클래스에서도 private로 선언된 number1의 값을 가져오거나 수정 할수있음 
   public int Number1  // 은닉성을 위배하지 않고 캡슐화 한 프로퍼티
   {
      get { return number1; }
      set { number1 = value; }
   }
   public int number2 { get; } = 20; // 내/외부에서 초기 설정 값만 사용가능하도록 설정
   public int number3 { get; private set; } = 30; // 내부를 통해서 수정 가능

   private void Start()
   {
      number1 = 100;
      // number2 = 200; // 수정불가
      number3 = 300;
   }
}
