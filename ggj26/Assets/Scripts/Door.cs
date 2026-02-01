using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openedDoor;
    public GameObject closedDoor;

    public bool isOpen = false;
    public bool isHidden = false;

    public void Awake()
    {
        UpdateDoors();
    }

    public void OpenDoor()
    {
        isOpen = true;
        UpdateDoors();
    }

    public void CloseDoor()
    {
        isOpen = false;
        UpdateDoors();
    }

    public void HideDoor()
    {
        isHidden = true;
        UpdateDoors();
    }
    public void ShowDoor()
    {
        isHidden = false;
        UpdateDoors();
    }


    public void UpdateDoors()
    {
        if (isHidden)
        {
            openedDoor.SetActive(false);
            closedDoor.SetActive(false);
            return;
        }
        openedDoor.SetActive(isOpen);
        closedDoor.SetActive(!isOpen);
    }



}
