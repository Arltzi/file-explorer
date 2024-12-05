using UnityEngine;

public class DraggablesHolder : MonoBehaviour
{
    [SerializeField]
    private float hboxWidth;
    public static DraggablesHolder instance;
    private DraggableIcon icons;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateDraggablesPosition()
    {

    }

    private void SortDraggables()
    {

    }

    public void ReturnDraggables()
    {
        foreach (Transform draggableTransform in transform)
        {
            draggableTransform.GetComponent<DraggableIcon>().ResetBlock();
        }
    }
}
