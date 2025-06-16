using UnityEngine;

public abstract class NPC :  Charactor
{
    public float hp;
    public float moveSpeed;

    public abstract void Move();

    public virtual void Talk()
    {

    }

    public virtual void talk()
    {

    }
}