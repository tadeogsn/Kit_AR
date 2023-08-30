using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(GsnRaycastObject))]
public class RaycastColor : MonoBehaviour
{
   
    public Color[] defaultColor;

    public Color overColor = Color.cyan;

    public Color downColor = Color.yellow;

    public Color clickedColor = Color.magenta;

    private GsnRaycastObject raycastObject;

    private Renderer objectRenderer;
    



    private void Awake()
    {
        raycastObject = gameObject.GetComponent<GsnRaycastObject>();
        objectRenderer = gameObject.GetComponent<Renderer>();
        
        defaultColor = new Color[objectRenderer.materials.Length];//nuevo tamaño a la varible deacuerdo al numero de materiales que hay en el objeto
                                                                  //objectRenderer.material.color = defaultColor;
        for (int i = 0; i < objectRenderer.materials.Length; i++)
        {
            //objectRenderer.materials[i].color = defaultColor;
            defaultColor[i] = objectRenderer.materials[i].GetColor("_Color");
        }
    }

    private void OnEnable()
    {
        
        if (raycastObject)
        {
            raycastObject.OnPointerOff.AddListener(Off);
            raycastObject.OnPointerOver.AddListener(Over);
            raycastObject.OnPointerUp.AddListener(Clicked);
            raycastObject.OnPointerDown.AddListener(Down);
        }
    }

    private void OnDisable()
    {
        
        if (raycastObject)
        {
            raycastObject.OnPointerOff.RemoveListener(Off);
            raycastObject.OnPointerOver.RemoveListener(Over);
            raycastObject.OnPointerUp.RemoveListener(Clicked);
            raycastObject.OnPointerDown.RemoveListener(Down);
        }
    }

    private void Off()
    {

        for (int i = 0; i < objectRenderer.materials.Length; i++)
        {
            //objectRenderer.material.color = defaultColor;
            objectRenderer.materials[i].color = defaultColor[i];
        }

    }

    private void Over()
    {
        
        for (int i = 0; i < objectRenderer.materials.Length; i++)
        {
            //objectRenderer.material.color = overColor;
            objectRenderer.materials[i].color = overColor;
        }

    }

    private void Down()
    {
        for (int i = 0; i < objectRenderer.materials.Length; i++)
        {
            //objectRenderer.material.color = downColor;
            objectRenderer.materials[i].color = downColor;
        }


    }

    private void Clicked()
    {

        //Debug.Log("dio click");
        for (int i = 0; i < objectRenderer.materials.Length; i++)
        {
            //objectRenderer.material.color = clickedColor;
            objectRenderer.materials[i].color = clickedColor;
        }


    }
}

