using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DraggableIcon : MonoBehaviour
{
    [SerializeField]
    private Tile tile;
    private bool selected = false;
    private Vector3 startPos;
    private Tilemap grid;
    private Vector3Int curGridPos;

    void Start()
    {
        startPos = transform.position;
        grid = GameObject.FindWithTag("SublevelTilemap").GetComponent<Tilemap>();
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
        Pickup();
    }

    void OnMouseUp()
    {
        Drop();
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
        curGridPos = grid.WorldToCell(transform.position);
    }

    void Drop()
    {
        TryPlaceElement();
    }

    bool TryPlaceElement()
    {
        selected = false;

        if(!grid.HasTile(curGridPos))
        {
            grid.SetTile(curGridPos, tile);
            DisableSelf();
            return true;
        }
        else
        {
            transform.position = startPos;
            curGridPos = Vector3Int.zero;
            return false;
        }
    }

    public void ResetBlock()
    {
        grid.SetTile(curGridPos, null);
        gameObject.SetActive(true);
        selected = false;
        transform.position = startPos;
        curGridPos = Vector3Int.zero;
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
