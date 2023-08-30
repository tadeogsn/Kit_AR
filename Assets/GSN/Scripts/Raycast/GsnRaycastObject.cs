using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class GsnRaycastObject : MonoBehaviour
{
    public UnityEvent OnPointerDown;
    public UnityEvent OnPointerUp;
    public UnityEvent OnPointerOver;
    public UnityEvent OnPointerOff;

    public void PointerDown()
    {
        Debug.Log("pointerDownd");
        OnPointerDown.Invoke();
    }

    public void PointerUp()
    {
        OnPointerUp.Invoke();
    }

    public void PointerOver()
    {
        OnPointerOver.Invoke();
    }

    public void PointerOff()
    {
        
        OnPointerOff.Invoke();
    }
}

