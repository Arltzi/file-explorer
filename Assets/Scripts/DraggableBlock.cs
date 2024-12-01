using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DraggableBlock : MonoBehaviour
{
    private bool placed = false;
    private bool selected = false;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if(selected)
        {
            Drag();
        }
    }

    void OnMouseDown()
    {
        if(!placed)
        {
            Pickup();
        }
    }

    void OnMouseUp()
    {
        if(!placed)
        {
            Drop();
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ResetBlock();
        }
    }

    void Pickup()
    {
        selected = true;
    }

    void Drag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
    }

    void Drop()
    {
        TryPlaceElement(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)));
    }

    bool TryPlaceElement(Vector3 worldPos)
    {
        List<Collider2D> colliders = new List<Collider2D>(); 
        GetComponent<Collider2D>().Overlap(colliders);

        selected = false;

        if(colliders.Count == 0)
        {
            placed = true;
            return true;
        }
        else
        {
            transform.position = startPos;
            return false;
        }
    }

    void ResetBlock()
    {
        placed = false;
        selected = false;
        transform.position = startPos;
    }
    
    void DisableSelf()
    {
        enabled = false;
    }
}
