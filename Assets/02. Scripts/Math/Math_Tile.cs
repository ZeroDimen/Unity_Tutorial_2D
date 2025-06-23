using System;
using UnityEngine;

public class Math_Tile : MonoBehaviour
{
    public GameObject[] canonPrefabs;

    private void OnMouseDown()
    {
        Instantiate(canonPrefabs[Math_SetTile.turretIndex], transform.position, Quaternion.identity);
    }
}
