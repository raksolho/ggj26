using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject openedDoor;
    public GameObject closedDoor;

    public GameObject openDoorDialogue;
    public GameObject closedDoorDialogue;
    public bool isDoorUnlocked=false;


    public void HideDoor()
    {
        openedDoor.SetActive(false);
        closedDoor.SetActive(false);
        openDoorDialogue.SetActive(false);
        closedDoorDialogue.SetActive(false);
    }

    public void UnlockDoor()
    {
        isDoorUnlocked = true;
    }
    public void ShowDoor()
    {
        if (isDoorUnlocked)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
    public void OpenDoor()
    {
        openedDoor.SetActive(true);
        closedDoor.SetActive(true);
        openDoorDialogue.SetActive(true);
        closedDoorDialogue.SetActive(false);

    }
    public void CloseDoor()
    {
        openedDoor.SetActive(false);
        closedDoor.SetActive(true);
        openDoorDialogue.SetActive(false);
        closedDoorDialogue.SetActive(true);
    }



}
