using UnityEngine;

public class Enemy : Entity
{
    protected override void Die()
    {
        Debug.Log("RIP " + name);
        Destroy(gameObject);
    }
}