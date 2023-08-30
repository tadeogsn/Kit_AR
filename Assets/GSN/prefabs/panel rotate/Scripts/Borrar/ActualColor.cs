using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualColor : MonoBehaviour
{
    public Color actual;
    private Renderer objetoActual;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        objetoActual = gameObject.GetComponent<Renderer>();
        actual = objetoActual.materials[0].GetColor("_Color");
    }
}
