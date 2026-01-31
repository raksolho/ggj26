using UnityEngine;


[RequireComponent(typeof(Renderer))]
public class LayerChanger : MonoBehaviour
{
    public Transform targetObject;
    public Transform referenceObject;

    public int greaterLayer;
    public int smallerLayer;

    void Update()
    {
        if (targetObject.position.y > referenceObject.position.y)
        {
            SetLayer(greaterLayer);
        }
        else
        {
            SetLayer(smallerLayer);
        }
    }

    void SetLayer(int layer)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingOrder = layer;
    }
}
