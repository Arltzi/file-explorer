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
        if(TrySpawnElement(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z))))
        {
            // succeeds at spawning element
            // TODO: organize by assigning to be a child of a "placed objects" object
        }
        else
        {
            // fails to spawn element
            // return icon to beginning, deselect
            selected = false;
            transform.position = startPos;
        }
    }

    bool TrySpawnElement(Vector3 worldPos)
    {
        Collider2D firstColl = Physics2D.BoxCast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z)), element.GetComponent<BoxCollider2D>().size, 0, Vector2.zero).collider;
        // Debug.Log(firstColl);
        if(!firstColl)
        {
            Instantiate(element, worldPos, Quaternion.identity);
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    void ResetIcon()
    {

    }
    
    void DisableSelf()
    {
        enabled = false;
    }
}
