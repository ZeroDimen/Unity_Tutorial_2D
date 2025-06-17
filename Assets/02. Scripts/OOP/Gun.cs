using UnityEngine;

public class Gun : MonoBehaviour, IDropItem
{
    public GameObject bulletPrefab;
    public Transform shootPos;
    
    public void Grab(Transform GrabpPos)
    {
        transform.SetParent(GrabpPos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        Debug.Log("총을 주웠다.");
    }

    public void Use()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos); // 원점 생성
        
        gameObject.transform.localPosition += gameObject.transform.forward * (10f * Time.deltaTime);
        Debug.Log("총을 발사한다.");
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;
        Debug.Log("총을 버렸다.");
    }
}