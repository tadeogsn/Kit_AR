using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;



public class Prueba_borrar : MonoBehaviour
{
    public Color Transparencia;
    private Color[] default_color;
    private MeshRenderer[] hijos;

    public bool ActivarTransparencia;
     void Start()
    {
        
            //hijos = new MeshRenderer[hijos.Length];
            hijos = gameObject.GetComponentsInChildren<MeshRenderer>();
            default_color = new Color[hijos.Length];
            for (int i = 0; i < hijos.Length; i++)
            {
                for (int x = 0; x < hijos[i].GetComponent<MeshRenderer>().materials.Length; x++)
                {
                Debug.Log("valor de I " + i);
                //default_color = new Color[x];
                   default_color[i] = hijos[i].materials[x].GetColor("_Color");
                }
            }
    }

    private void Update()
    {
        if (ActivarTransparencia==true)
        {
            EnableTransparency();
        }
        else
        {
            DisableTransparency();
        }
    }

    public void EnableTransparency()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("Transparency works only in playing mode");
            return;
        }


       
            foreach (var go in hijos)
                StartCoroutine(EnableTransparencyCor(go));
            Debug.LogWarning("Transparency works only in playing mode");
        

    }
    public void DisableTransparency()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("Transparency works only in playing mode");
            return;
        }
        StartCoroutine(DisableTransparencyCor());
        //for (int i = 0; i < child_opaque.Length; i++)//2
        //{
        //	foreach (var go in child_opaque[i].defaultColor)
        //		StartCoroutine(DisableTransparencyCor(go));

        //}

    }
    IEnumerator DisableTransparencyCor()
    {


        /////////////////////////

        ///////////////


        //}
        for (int i = 0; i < hijos.Length; i++)//2
        {

            
                for (int y = 0; y < hijos[i].materials.Length; y++)
                {
                //child_opaque[i].Hijos_Class.GetComponent<Collider>().enabled = true;//Activar collider
                hijos[i].materials[y].color =default_color[i];
                hijos[i].materials[y].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                hijos[i].materials[y].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                hijos[i].materials[y].SetInt("_ZWrite", 1);
                hijos[i].materials[y].DisableKeyword("_ALPHATEST_ON");
                hijos[i].materials[y].DisableKeyword("_ALPHABLEND_ON");
                hijos[i].materials[y].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                hijos[i].materials[y].renderQueue = -1;

                }
            
        }
        yield return null;
    }
    IEnumerator EnableTransparencyCor(MeshRenderer go)
    {
        gameObject.GetComponent<Prueba_borrar>().enabled = true;
        go.GetComponent<Collider>().enabled = false;//desactivar collider
        Debug.Log("SI ENTREO" + go);
        ///////////////
        ///

        for (int y = 0; y < go.materials.Length; y++)
        {
            Debug.Log("Entro en la transparencia");
            go.materials[y].SetFloat("_Mode", 3f);
            go.materials[y].renderQueue = 3000;
            go.materials[y].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            go.materials[y].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            go.materials[y].SetInt("_ZWrite", 0);
            go.materials[y].DisableKeyword("_ALPHATEST_ON");
            go.materials[y].EnableKeyword("_ALPHABLEND_ON");
            go.materials[y].DisableKeyword("_ALPHAPREMULTIPLY_ON");
            go.materials[y].color = Transparencia;
        }

        yield return null;
        //	}
    }
}