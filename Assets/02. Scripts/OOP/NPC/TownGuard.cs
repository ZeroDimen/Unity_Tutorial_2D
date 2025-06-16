using UnityEngine;

public class TownGuard : MonoBehaviour , IMove , IAttack
{
    public void Move()
    {
        Debug.Log("Move");
    }

    public void Talk()
    {
        Debug.Log("Talk");
    }
}