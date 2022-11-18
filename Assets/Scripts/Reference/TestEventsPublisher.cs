using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class TestEventsPublisher : MonoBehaviour
{
    // event handler delegate
    public event EventHandler<OnSpacePressedEventArgs> OnSpacePressed;
    public class OnSpacePressedEventArgs : EventArgs
    {
        public int spaceCount;
    }

    // custom delegate
    public delegate void TestEventDelegate(float f);
    public event TestEventDelegate OnFloatEvent;

    // default delegate
    public event Action<bool> OnActionEvent; 

    // unity's event, it's just regular events but it appears in inspector
    public UnityEvent<string> OnUnityEvent; 

    private int spaceCount = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceCount++;
            OnSpacePressed?.Invoke(this, new OnSpacePressedEventArgs{spaceCount = spaceCount });
            OnFloatEvent?.Invoke(5.5f);
            OnActionEvent?.Invoke(true);
            OnUnityEvent?.Invoke("Goodbye cruel world!");
        }
    }
}
