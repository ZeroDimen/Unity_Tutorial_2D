using UnityEngine;

// virtual : 선택적 재정의
// abstract : 필수적 재정의
// interface : 필수적 구현
public class TownPerson : MonoBehaviour, IMove, ITalk
{
        public float hp;
        public float speed;


        public void Move()
        {
                Debug.Log("Move");
        }
        
        public void Talk()
        {
                Debug.Log("Talk");
        }
}