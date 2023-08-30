using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class Hijos_Tranparencia
{
	public MeshRenderer[] Hijos_Class;
	public Color[] defaultColor;
}

public class PadreHijoTransparency : MonoBehaviour
{

	public bool ShowGUI;
	public Color transparency;
	public GameObject[] padre_transparencia;
	public Hijos_Tranparencia[] child_opaque;

	/// </summary>
	public bool bandera;
	void Awake()
	{

		child_opaque = new Hijos_Tranparencia[padre_transparencia.Length];
		gameObject.SetActive(true);
	}



	void Start()
	{
		//ERRORES CUANDO EJECUTAS SIRVE PERO SI NO TIENES SELECCIONADO EL OBJETO QUE CONTIENE EL SCRIPT DEJA DE FUNCIONAR
		//StartCoroutine(Inicio());
		//gameObject.GetComponent<Enginei4>().enabled=true;
		//Debug.Log("Entro integramente");

		///////////funciona

		//for (int i = 0; i < child_opaque.Length; i++)//2
		//{
		//	child_opaque[i].defaultColor = new Color[padre_transparencia[i].GetComponentsInChildren<MeshRenderer>().Length];//default= 74-> padre_transparencia 2 con 0-74, 1-60
		//	child_opaque[i].Hijos_Class = padre_transparencia[i].GetComponentsInChildren<MeshRenderer>();

		//		for (int x = 0; x < child_opaque[i].defaultColor.Length; x++)
		//		{
		//			for (int y = 0; y < child_opaque[i].Hijos_Class[x].materials.Length; y++)
		//			{
		//			child_opaque[i].defaultColor[x] = child_opaque[i].Hijos_Class[x].materials[y].GetColor("_Color");

		//			}
		//		}

		//}
		///////////////////prueba
		foreach (var child in child_opaque)//2
		{
			foreach (var tranpa in padre_transparencia)//2
			{

				child.Hijos_Class = tranpa.GetComponentsInChildren<MeshRenderer>();
				Debug.Log("++++++++++++++++++++++++++++nose");
				child.defaultColor = new Color[tranpa.GetComponentsInChildren<MeshRenderer>().Length];//default= 74-> padre_transparencia 2 con 0-74, 1-60


				for (int x = 0; x < child.defaultColor.Length; x++)
				{

					for (int y = 0; y < child.Hijos_Class[x].materials.Length; y++)
					{
						child.defaultColor[x] = child.Hijos_Class[x].materials[y].GetColor("_Color");

					}
				}

			}
		}


	}
	//   private void Update()
	//   {
	//       if (bandera== false)
	//	{

	//		bandera = true;
	//	}

	//}

	void OnGUI()
	{
		if (!ShowGUI) return;

		GUI.Box(new Rect(Screen.width - 207, 5, 207, 380), " ");

		GUI.Label(new Rect(Screen.width - 200, 5, 80, 20), "RPM");

		if (GUI.Button(new Rect(Screen.width - 200, 80, 195, 20), "Enable transparency")) EnableTransparency();
		if (GUI.Button(new Rect(Screen.width - 200, 105, 195, 20), "Disable transparency")) DisableTransparency();


	}

	//public void ActivateAllObjects()
	//{
	//	foreach (var mr in transform.GetComponentsInChildren<MeshRenderer>(true))
	//		mr.gameObject.SetActive(true);
	//}


	public void EnableTransparency()
	{
		if (!Application.isPlaying)
		{
			Debug.LogWarning("Transparency works only in playing mode");
			return;
		}


		for (int i = 0; i < child_opaque.Length; i++)//2
		{
			foreach (var go in child_opaque[i].Hijos_Class)
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
		StartCoroutine(DisableTransparencyCor());
		//for (int i = 0; i < child_opaque.Length; i++)//2
		//{
		//	foreach (var go in child_opaque[i].defaultColor)
		//		StartCoroutine(DisableTransparencyCor(go));

		//}

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
			go.materials[y].color = transparency;
		}

		yield return null;
		//	}
	}


	IEnumerator DisableTransparencyCor()
	{


		/////////////////////////

		///////////////


		//}
		for (int i = 0; i < child_opaque.Length; i++)//2
		{

			for (int x = 0; x < child_opaque[i].defaultColor.Length; x++)
			{
				for (int y = 0; y < child_opaque[i].Hijos_Class[x].materials.Length; y++)
				{
					//child_opaque[i].Hijos_Class.GetComponent<Collider>().enabled = true;//Activar collider
					child_opaque[i].Hijos_Class[x].materials[y].color = child_opaque[i].defaultColor[x];
					child_opaque[i].Hijos_Class[x].materials[y].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
					child_opaque[i].Hijos_Class[x].materials[y].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
					child_opaque[i].Hijos_Class[x].materials[y].SetInt("_ZWrite", 1);
					child_opaque[i].Hijos_Class[x].materials[y].DisableKeyword("_ALPHATEST_ON");
					child_opaque[i].Hijos_Class[x].materials[y].DisableKeyword("_ALPHABLEND_ON");
					child_opaque[i].Hijos_Class[x].materials[y].DisableKeyword("_ALPHAPREMULTIPLY_ON");
					child_opaque[i].Hijos_Class[x].materials[y].renderQueue = -1;

				}
			}
		}
		yield return null;
	}



	//void Update()
	//{
	//}
}