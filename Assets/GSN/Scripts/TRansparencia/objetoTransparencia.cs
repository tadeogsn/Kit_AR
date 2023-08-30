using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TranparenciaObjetos
{
	public List<Renderer> defaultMaterial = new List<Renderer>();
	public Color[] defaultColor;
}

public class objetoTransparencia : MonoBehaviour
{

	public bool ShowGUI;
	//public Color transparency;
	public GameObject[] padre_transparencia;
	public TranparenciaObjetos[] ValoresCargadosAutomaticamente;

	 
	 public Material materialTransparente;
	
	void Awake()
	{
		
	}
	void Start()
	{
		for (int i = 0; i < ValoresCargadosAutomaticamente.Length; i++)//2
		{
			ValoresCargadosAutomaticamente[i].defaultColor  = new Color[padre_transparencia[i].GetComponentsInChildren<Renderer>().Length];//default= 74-> padre_transparencia 2 con 0-74, 1-60
			ValoresCargadosAutomaticamente[i].defaultMaterial.AddRange(padre_transparencia[i].GetComponentsInChildren<Renderer>());

			for (int x = 0; x < ValoresCargadosAutomaticamente[i].defaultColor.Length; x++)
			{
				for (int y = 0; y < ValoresCargadosAutomaticamente[i].defaultMaterial[x].materials.Length; y++)
				{
				   ValoresCargadosAutomaticamente[i].defaultColor[x] = ValoresCargadosAutomaticamente[i].defaultMaterial[x].materials[y].GetColor("_Color");
				}
			}

		}
		
	}

	void OnGUI()
	{
		if (!ShowGUI) return;

		GUI.Box(new Rect(Screen.width - 207, 5, 207, 380), " ");

		GUI.Label(new Rect(Screen.width - 200, 5, 80, 20), "RPM");

		if (GUI.Button(new Rect(Screen.width - 200, 80, 195, 20), "Enable transparency")) EnableTransparency();
		if (GUI.Button(new Rect(Screen.width - 200, 105, 195, 20), "Disable transparency")) DisableTransparency();


	}
	public void EnableTransparency()
	{
		
		if (!Application.isPlaying)
		{
			Debug.LogWarning("Transparency works only in playing mode");
			return;
		}


		for (int i = 0; i < ValoresCargadosAutomaticamente.Length; i++)//2
		{
			foreach (var go in ValoresCargadosAutomaticamente[i].defaultMaterial)
				StartCoroutine(EnableTransparencyCor(go));
				Debug.LogWarning("Transparency works only in playing mode");
		}

	}


	public void DisableTransparency()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("Transparency works only in playing mode");
			return;
		}

		for (int i = 0; i < ValoresCargadosAutomaticamente.Length; i++)//2
		{
			foreach (var go in ValoresCargadosAutomaticamente[i].defaultMaterial)
				StartCoroutine(DisableTransparencyCor(go));
			Debug.LogWarning("Transparency works only in playing mode");
		}

	}


	IEnumerator EnableTransparencyCor(Renderer go)
	{   
		 //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                Transform[] all = go.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=10;//10 pertenece al layer de transparencia
                }
            //FIN LAYER
        go.material = materialTransparente;
		yield return null;
		//	}
	}


	IEnumerator DisableTransparencyCor(Renderer go)
	{
		//LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                Transform[] all = go.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=0;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
		
		for (int x = 0; x< ValoresCargadosAutomaticamente.Length; x++)//2
		{
			for (int y = 0; y < ValoresCargadosAutomaticamente[x].defaultMaterial.Count; y++)
        	{
        	    for (int i = 0; i < ValoresCargadosAutomaticamente[x].defaultMaterial[y].GetComponent<MeshRenderer>().materials.Length; i++)
        	    {
        	       ValoresCargadosAutomaticamente[x].defaultMaterial[y].materials[i].shader = Shader.Find("Standard");
        	       ValoresCargadosAutomaticamente[x].defaultMaterial[y].materials[i].color  = ValoresCargadosAutomaticamente[x].defaultColor[y];
        	    }
        	}
		}
		yield return null;
	}
}
