using UnityEngine;
using UnityEngine.UIElements;

public class DraggableBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject element;
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
        Pickup();
    }

    void OnMouseUp()
    {
        Drop();
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
        selected = false;
        TrySpawnElement(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)));
    }

    void TrySpawnElement(Vector3 worldPos)
    {
        // TODO: organize by assigning to be a child of a "placed objects" object
        Instantiate(element, worldPos, Quaternion.identity);
        Destroy(gameObject);
    }
    
    void DisableSelf()
    {
        enabled = false;
    }
}
