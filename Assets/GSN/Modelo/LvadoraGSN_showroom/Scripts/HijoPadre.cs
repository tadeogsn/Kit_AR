using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Hijos
{
    public MeshRenderer[] Hijos_class;
}
public class HijoPadre : MonoBehaviour
{
    public GameObject[] padre;
    public Hijos[] child;

    // Start is called before the first frame update
    void Awake()
    {
        child = new Hijos[padre.Length];
    }
    void Start()
    {
        for (int x = 0; x < child.Length; x++)
        {
           
            //Debug.Log("Padre " + x);
            child[x].Hijos_class = padre[x].GetComponentsInChildren<MeshRenderer>();


        }



    }




	// Update is called once per frame

}
