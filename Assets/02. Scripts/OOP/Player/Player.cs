using UnityEngine;

public class Player : Charactor
{
   public override void Attack()
   {
      // base.Attack();// 부모 클래스의 Attack
      Debug.Log("Player 공격");
   }

   public override void Hit() // 무조건 override를 해야함
   {
      
   }
}