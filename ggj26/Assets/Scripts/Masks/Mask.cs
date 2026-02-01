using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Mask", menuName = "Scriptable Objects/Mask")]
public class Mask : ScriptableObject
{
    public string maskName;
    public Sprite maskSprite;
    public Sprite maskOverlay;

    public bool followCamera = false;
    public Vector3 positionOffset;
    public Vector3 positionOffset2;
}
