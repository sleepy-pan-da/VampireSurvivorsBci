using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestEventsSubscriber : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        TestEventsPublisher childComponent = transform.Find("Child").GetComponent<TestEventsPublisher>();
        childComponent.OnSpacePressed += OnChildSpacePressed;
        childComponent.OnFloatEvent += OnChildFloatEvent;
        childComponent.OnActionEvent += OnChildActionEvent;
    }

    private void OnChildSpacePressed(object sender, TestEventsPublisher.OnSpacePressedEventArgs e) {
        Debug.Log("Num of spaces: " + e.spaceCount.ToString());
    }

    private void OnChildFloatEvent(float input) {
        Debug.Log(input.ToString());
    }

    private void OnChildActionEvent(bool defaultBool) {
        Debug.Log(defaultBool);
    }

    public void OnChildUnityEvent(string msg){
        Debug.Log(msg);
    }
}
