using UnityEngine;
using UnityEngine.Events;
public class CallUnityEvent : MonoBehaviour
{
    public UnityEvent myEvent;



    public void CallEvent()
    {
        myEvent.Invoke();
    }
}
