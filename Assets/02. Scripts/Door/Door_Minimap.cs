using System;
using UnityEngine;

// 플레이어 오브젝트를 따라가기위한 스크립트
public class Door_Minimap : MonoBehaviour
{
    public Transform target;
    private void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}
