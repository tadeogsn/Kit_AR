using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Raycascanvas : MonoBehaviour
{

    public UnityEvent True;
    public UnityEvent False;
    //public bool bandera;
    // Start is called before the first frame update
    void Start()
    {
        
        //Button ejmploButton = gameObject.GetComponentsInChildren<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void raycanvas()
    {
        
        if (gameObject.GetComponent<Toggle>().isOn == false)
        {
            ChangeValueToTrue();
        }
        else
        {
            ChangeValueToFalse();
        }

        

    }
    public void ChangeValueToTrue()
    {
        True.Invoke();
        Debug.Log("True");
        gameObject.GetComponent<Toggle>().isOn = true;

    }

    //Use buttons linked to this
    public void ChangeValueToFalse()
    {
        False.Invoke();
        Debug.Log("False");
        gameObject.GetComponent<Toggle>().isOn = false;
    }
}
