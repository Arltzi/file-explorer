using System.Runtime.CompilerServices;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]

public class JumpPad : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject go = collider.gameObject;
        if(go.CompareTag("Player"))
        {
            go.GetComponent<Rigidbody2D>().AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}
