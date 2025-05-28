using System;
using UnityEngine;

public class Cat_Spin : MonoBehaviour
{
    public GameObject a;

    private void FixedUpdate()
    {
        this.gameObject.transform.Rotate(Vector3.right);
    }
}
