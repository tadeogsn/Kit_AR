using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExampleClass : MonoBehaviour
{
    //[SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material defaultMaterial;
    private Vector3 _selection;
    Renderer selectionRenderer;
    private Collider previousCollider;
    private GsnRaycastObject previousRaycastObject;
    GsnRaycastObject raycastObject;
    private Button buttonRaycast;
    public float tiempo = 2.0f;
    public bool bandera;


    /// <summary>
    public Image gaze;
    public LayerMask excludeLayers;
    /// </summary>

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate() {
        
       

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, excludeLayers))
        {
            tiempo -= Time.deltaTime;
            func_gaze();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            //Debug.Log(gaze.fillAmount);
            raycastObject = hit.collider.gameObject.GetComponent<GsnRaycastObject>();
            raycastObject.PointerOver();
            if (tiempo < 1 && bandera == false)
            {
                
                //en esta parte vamos a usar la dfuncion de dar cliclk para poder desencadenar nuestro envento;

                Debug.Log("1");
                if (tiempo < .05)
                {
                    //gaze.enabled = false;
                    raycastObject.PointerUp();//hace click para desencadenar la accion;
                    //tiempo = 2.0f;
                    bandera = true;
                    Debug.Log("2");
                }
            }
           
            if (previousCollider != hit.collider)//si el collider pasado ya no golpea se desactiva el color 
            {
                tiempo = 2.0f;
                bandera = false;
                if (previousRaycastObject)
                {
                    previousRaycastObject.PointerOff();// desactiva el color

                    Debug.Log("0");

                }
                //else 
                //{ 
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    var selection = hit.transform;
                   
                    
                    previousRaycastObject = raycastObject;
                    Debug.Log("3");
                //}
                    
                    
                //}
                
            }

            previousCollider = hit.collider;
        }
        else
        {
            tiempo = 2.0f;
            bandera = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            if (previousRaycastObject)
            {
                previousRaycastObject.PointerOff();
                previousRaycastObject = null;
            }
            previousCollider = null;
            Debug.Log("4");

        }
    }

    void func_gaze()
    {
        gaze.fillAmount = tiempo *2 / 2;
        gaze.enabled = true;
        Debug.Log("5");
    }





}