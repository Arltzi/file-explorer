using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseDraggableTile : TileBase
{
    private bool placed = false;
    private bool selected = false;
    private Vector3Int startPos;

    void Start()
    {
        // startPos = position;
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
        // snap to grid center, gets first grid tagged with "SublevelTilemap"
        transform.position = grid.GetCellCenterWorld(grid.WorldToCell(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z))));
    }

    void Drop()
    {
        TryPlaceElement();
    }

    bool TryPlaceElement()
    {
        List<Collider2D> colliders = new List<Collider2D>(); 
        int colliderCount = Physics2D.OverlapCollider(GetComponent<Collider2D>(), colliders);

        selected = false;

        if(colliderCount == 0)
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
