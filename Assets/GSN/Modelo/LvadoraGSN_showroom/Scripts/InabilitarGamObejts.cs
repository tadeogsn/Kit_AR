using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InabilitarGamObejts : MonoBehaviour
{


	public bool ShowGUI;
	public Color transparency;
	public GameObject[] desactivarObejtos;
	//public Hijos_Desactivar[] child_opaque;

	/// </summary>
	public bool bandera;
	//void Awake()
	//{

	//	child_opaque = new Hijos_Desactivar[padre_transparencia.Length];
	//}



	void Start()
	{
		//for (int x = 0; x < desactivarObejtos.Length; x++)
		//{
		//	//Debug.Log("Padre " + x);
		//	desactivarObejtos = padre_transparencia[x].GetComponentsInChildren<MeshRenderer>();

		//}


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



		foreach (var go in desactivarObejtos)
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

		foreach (var go in desactivarObejtos)
			StartCoroutine(DisableTransparencyCor(go));



	}


	IEnumerator EnableTransparencyCor(GameObject go)
	{
		go.SetActive(false);

		yield return null;
		//	}
	}


	IEnumerator DisableTransparencyCor(GameObject go)
	{
		go.SetActive(true);

		yield return null;
	}
}
