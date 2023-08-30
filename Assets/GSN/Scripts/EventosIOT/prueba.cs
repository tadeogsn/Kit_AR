using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class prueba : MonoBehaviour
 {
   public GameObject Obj;

   public Text y;

   public Text x;
   public Text z;
   //public ExampleClass evitarlayer;
	// Use this for initialization
	  void Start ()
    {

        // Obj.transform.localRotation

       
        
         //LayerMask mask = LayerMask.GetMask("temperatura");
         //Debug.Log("nombre de layer mask"+mask);
         
	  }   

    // Update is called once per frame
    void Update()
    {
      y.text = Obj.transform.rotation.y.ToString();
      x.text = Obj.transform.rotation.x.ToString();
      z.text = Obj.transform.rotation.z.ToString();
        Debug.Log(Obj.transform.localPosition.y);
    }


}
