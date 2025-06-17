using UnityEngine;

public class FlashLight : MonoBehaviour , IDropItem
{
        public GameObject lightObj;
        public bool isLight;
        public void Grab(Transform GrabpPos)
        {
                transform.SetParent(GrabpPos); // 부모상태 계층구조 연결
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                
                Debug.Log("손전등을 주웠다.");
        }

        public void Use()
        {
                isLight = !isLight;
                if (isLight)
                {
                        lightObj.SetActive(true);
                        Debug.Log("손전등을 켠다");
                }
                else
                {
                        lightObj.SetActive(false);
                        Debug.Log("손전등을 끈다");
                }
        }

        public void Drop()
        {
                transform.SetParent(null); // 부모상태 계층구조 해제
                transform.position = Vector3.zero;
                Debug.Log("손전등을 버렸다.");
        }
}