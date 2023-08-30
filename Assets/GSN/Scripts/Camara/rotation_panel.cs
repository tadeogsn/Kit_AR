using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_panel : MonoBehaviour
{

    public GameObject OBJcamera;
    //public GameObject NameCamera;
   
    private Vector3 angulos;
    // Start is called before the first frame update
    void Start()
    {
        //camera.name = "First Person Camera";
    }

    // Update is called once per frame
    void Update()
    {
        if (OBJcamera== null)
        {
            OBJcamera = GameObject.Find("ARCamera");// este es el nombre de la camara de arcore
         //   Debug.Log("entro en el script");
        }
        //OBJcamera = GameObject.Find(OBJcamera.name);
        //Debug.Log(NameCamera.name);


        //var camera_selft=gameObject.fin
        angulos = OBJcamera.GetComponent<Transform>().rotation.eulerAngles;
     //   Debug.Log(OBJcamera.GetComponent<Transform>().rotation.eulerAngles);

        angulos.z = 0;

        gameObject.transform.rotation = Quaternion.Euler(angulos);
//        Debug.Log(angulos);
    }
}
