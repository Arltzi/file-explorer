using System.Runtime.CompilerServices;
using UnityEngine;

public class Corruption : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D otherCollision)
    {
        Debug.Log("collide with corruption");
        if (otherCollision.gameObject.GetComponent<PlayerController>())
        {
            otherCollision.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}
