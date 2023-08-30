using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveModel : MonoBehaviour
{

    public GameObject OBJcamera;
    //public GameObject NameCamera;
   
    private Vector3 anguloY;
    // Start is called before the first frame update
    void Start()
    {
        if (OBJcamera== null)
        {
            OBJcamera = GameObject.Find("ARCamera");// este es el nombre de la camara de arcore
            Debug.Log("entro en el script");
        }
        //OBJcamera = GameObject.Find(OBJcamera.name);
        //Debug.Log(NameCamera.name);


        //var camera_selft=gameObject.fin
        anguloY = OBJcamera.GetComponent<Transform>().rotation.eulerAngles;
        //Debug.Log(OBJcamera.GetComponent<Transform>().rotation.eulerAngles);

        anguloY.z = 0;
        anguloY.x = 0;

        gameObject.transform.rotation = Quaternion.Euler(anguloY);
        Debug.Log(anguloY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
