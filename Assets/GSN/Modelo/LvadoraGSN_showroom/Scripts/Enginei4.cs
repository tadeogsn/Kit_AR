using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


[System.Serializable]
public class EngineVariation{
	public GameObject[] gameObjects;
}


[System.Serializable]
public class Tweaks{
	public float 
		TransparencyEnablingTime,
		TransparencyDisablingTime;

	[Range(0,1)]
	public float TransparencyValue=0.1f;
}
	

[System.Serializable]
public class Valve{
	public GameObject 
		ValveGameobject,
		SpringGameobject;

	public float 
		OpenPhase,
		ClosePhase;

	[HideInInspector]
	public Vector3 DefPos;
}


[System.Serializable]
public class EngineElements {
	public Valve[]
		intakeValves,
		exhaustValves;

	public GameObject[] piezasDeMaquina;
}

public class Enginei4 : MonoBehaviour {
	[Header("System")]
	public EngineElements elements;

	public EngineVariation[] engineVariations;

	public GameObject[] TransparentGameobjects;

	public Material FadeMaterial; 
		
	public GameObject[] OpaqueMaterial;


	[Header("Contorls")]

	public bool ShowGUI;

	[Range(0,30)]
	public float RPM;

	public Tweaks tweaks;

	private Vector3 
		Piston1DefPos,
		Piston2DefPos,
		Piston3DefPos,
		Piston4DefPos,
		Rod1DefPos,
		Rod2DefPos,
		Rod3DefPos,
		Rod4DefPos,
		ValveIntake1DefPos,
		ValveIntake2DefPos,
		ValveExhaust1DefPos,
		ValveExhaust2DefPos,
		ValveSpringOffset,
		ValveOffset;

	private float 
		IntakePhase,
		ExhaustPhase,
		Piston1Delta,
		Piston2Delta,
		Piston3Delta,
		Piston4Delta;

	private Material
		Transparencia;

	public Color[] defaultColor;
	public Color transparency ;

	//public Material matee;


	void Start () {
		//nuevo tamaño a la varible deacuerdo al numero de materiales que hay en el objeto
		//objectRenderer.material.color = defaultColor;
		defaultColor = new Color[TransparentGameobjects.Length];
		OpaqueMaterial = new GameObject[TransparentGameobjects.Length];
		
		Debug.Log("lenght de tranparent object"+ TransparentGameobjects.Length);
		for (int i = 0; i < TransparentGameobjects.Length; i++)
		{
			Debug.Log("ARRay " + TransparentGameobjects[i].name);
			for (int x = 0; x < TransparentGameobjects[i].GetComponent<MeshRenderer>().materials.Length; x++)
			{

				Debug.Log("valor de I = " + x);
				OpaqueMaterial[i] = GameObject.Find(TransparentGameobjects[i].name);

				defaultColor[i] = TransparentGameobjects[i].GetComponent<MeshRenderer>().materials[x].GetColor("_Color");
				//Debug.Log("nose que poner" + OpaqueMaterial[i].GetComponent<Material>().color);
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].color = defaultColor[i];
				
				 //matee = OpaqueMaterial[i].GetComponent<Material>().color;

			}

        }
		/////////////////////////////

		ValveOffset = new Vector3 (0, 0, 0.01f);
		ValveSpringOffset = new Vector3 (0, 0, 0.29f);
		for (int i = 0; i < elements.piezasDeMaquina.Length; i++)
		{
			Transparencia = elements.piezasDeMaquina[i].GetComponent<MeshRenderer>().material;
		}

		//Piston1DefPos = elements.Piston1.transform.localPosition;
		//Piston2DefPos = elements.Piston2.transform.localPosition;
		//Piston3DefPos = elements.Piston3.transform.localPosition;
		//Piston4DefPos = elements.Piston4.transform.localPosition;

		//Rod1DefPos = transform.InverseTransformPoint (elements.Rod1.transform.position);
		//Rod2DefPos = transform.InverseTransformPoint (elements.Rod2.transform.position);
		//Rod3DefPos = transform.InverseTransformPoint (elements.Rod3.transform.position);
		//Rod4DefPos = transform.InverseTransformPoint (elements.Rod4.transform.position);

		foreach (var valve in elements.intakeValves) 
			valve.DefPos = valve.ValveGameobject.transform.localPosition;

		foreach (var valve in elements.exhaustValves) 
			valve.DefPos = valve.ValveGameobject.transform.localPosition;

	}

	  


       void OnGUI(){
		if (!ShowGUI) return;

		GUI.Box(new Rect(Screen.width-207,5,207,380)," ");
		
		GUI.Label (new Rect (Screen.width-200, 5, 80, 20), "RPM");

		RPM = GUI.HorizontalSlider (new Rect (Screen.width-170, 10, 160, 20), RPM, 0, 30);
		
		if (GUI.Button (new Rect (Screen.width-200, 30, 95, 20), "Tuning 1")) SetVariation (0);
		if (GUI.Button (new Rect (Screen.width-100, 30, 95, 20), "Tuning 2")) SetVariation (1);
		if (GUI.Button (new Rect (Screen.width-200, 55, 95, 20), "Tuning 3")) SetVariation (2);
		if (GUI.Button (new Rect (Screen.width-100, 55, 95, 20), "Tuning 4")) SetVariation (3);

		if (GUI.Button (new Rect (Screen.width-200, 80, 195, 20), "Enable transparency")) EnableTransparency ();
		if (GUI.Button (new Rect (Screen.width-200, 105, 195, 20), "Disable transparency")) DisableTransparency ();
		
		//elements.EngineBlock.SetActive(GUI.Toggle (new Rect (Screen.width-200, 130, 200,20), elements.EngineBlock.activeSelf, "Engine block"));
		//elements.CylinderHead.SetActive(GUI.Toggle (new Rect (Screen.width-200, 150, 200, 20), elements.CylinderHead.activeSelf, "Cylinder head"));
		//elements.CylinderHeadCovers.SetActive(GUI.Toggle (new Rect (Screen.width-200, 170, 200, 20), elements.CylinderHeadCovers.activeSelf, "Cylinder head covers"));
		//elements.Gearbox.SetActive(GUI.Toggle (new Rect (Screen.width-200, 190, 200, 20), elements.Gearbox.activeSelf, "Gearbox"));
		//elements.ExhaustManifolds.SetActive(GUI.Toggle (new Rect (Screen.width-200, 210, 200, 20), elements.ExhaustManifolds.activeSelf, "Exhaust manifold"));
		//elements.FuelRail.SetActive(GUI.Toggle (new Rect (Screen.width-200, 230, 200, 20), elements.FuelRail.activeSelf, "Fuel rail"));
		//elements.IntakeManifolds.SetActive(GUI.Toggle (new Rect (Screen.width-200, 250, 200, 20), elements.IntakeManifolds.activeSelf, "Intake manifold"));
		//elements.Flywheel.SetActive(GUI.Toggle (new Rect (Screen.width-200, 270, 200, 20), elements.Flywheel.activeSelf, "Flywheel"));
		//elements.Clutch.SetActive(GUI.Toggle (new Rect (Screen.width-200, 290, 200, 20), elements.Clutch.activeSelf, "Clutch"));
		//elements.OilPan.SetActive(GUI.Toggle (new Rect (Screen.width-200, 310, 200, 20), elements.OilPan.activeSelf, "Oil pan"));
		//elements.SparkPlugWires.SetActive(GUI.Toggle (new Rect (Screen.width-200, 330, 200, 20), elements.SparkPlugWires.activeSelf, "Spark plug wires"));
		//elements.SparkPlugs.SetActive(GUI.Toggle (new Rect (Screen.width-200, 350, 200, 20), elements.SparkPlugs.activeSelf, "Spark plugs"));

		
	}
		

	public void SetVariation(int variation){
		ActivateAllObjects ();

		foreach (var _variation in engineVariations)
			foreach (var gameobject in _variation.gameObjects)
				gameobject.SetActive (false);

		foreach (var gameobject in engineVariations[variation].gameObjects)
			gameobject.SetActive (true);
	}


	public void ActivateAllObjects(){
		foreach (var mr in transform.GetComponentsInChildren<MeshRenderer>(true))
			mr.gameObject.SetActive (true);
	}


	public void EnableTransparency() {
		if (!Application.isPlaying) {
			Debug.LogWarning("Transparency works only in playing mode");
			return;
		}
		Debug.Log("SI ENTREO");
		foreach (var go in TransparentGameobjects)
			StartCoroutine(EnableTransparencyCor(go));

  //      for (int i=0; i< TransparentGameobjects.Length; i++){
		//	TransparentGameobjects[i].GetComponent<Collider>().enabled = false;
		//}
	   


	}


	public void DisableTransparency(){
		if (!Application.isPlaying) {
			Debug.LogWarning ("Transparency works only in playing mode");
			return;
		}
		
		foreach (var go in TransparentGameobjects)
			StartCoroutine (DisableTransparencyCor (go));
	}


	IEnumerator EnableTransparencyCor(GameObject go){
		go.GetComponent<Collider>().enabled = false;//desactivar collider

		///////////////
		///
		for (int i = 0; i < TransparentGameobjects.Length; i++)
		{
			for (int x = 0; x < TransparentGameobjects[i].GetComponent<MeshRenderer>().materials.Length; x++)
			{
				Debug.Log("Entro en la transparencia");
				go.GetComponent<Renderer>().materials[x].SetFloat("_Mode", 3f);
				go.GetComponent<Renderer>().materials[x].renderQueue = 3000;
				go.GetComponent<Renderer>().materials[x].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
				go.GetComponent<Renderer>().materials[x].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
				go.GetComponent<Renderer>().materials[x].SetInt("_ZWrite", 0);
				go.GetComponent<Renderer>().materials[x].DisableKeyword("_ALPHATEST_ON");
				go.GetComponent<Renderer>().materials[x].EnableKeyword("_ALPHABLEND_ON");
				go.GetComponent<Renderer>().materials[x].DisableKeyword("_ALPHAPREMULTIPLY_ON");
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].color = transparency;
			}
		}
		//Material thisMaterial = go.GetComponent<MeshRenderer> ().material;
		//Material fadeMaterial=(Material)Instantiate(FadeMaterial);

		//go.GetComponent<MeshRenderer>().material=fadeMaterial;
		//fadeMaterial.SetTexture ("_MainTex", thisMaterial.GetTexture ("_MainTex"));
		//fadeMaterial.SetTexture ("_OcclusionMap", thisMaterial.GetTexture ("_OcclusionMap"));
		//fadeMaterial.SetTexture ("_BumpMap", thisMaterial.GetTexture ("_BumpMap"));

		//fadeMaterial.SetFloat ("_BumpScale", thisMaterial.GetFloat ("_BumpScale"));
		//fadeMaterial.SetFloat ("_Metallic", thisMaterial.GetFloat ("_Metallic"));
		//fadeMaterial.SetFloat ("_OcclusionStrength", thisMaterial.GetFloat ("_OcclusionStrength"));
		//fadeMaterial.SetFloat ("_Glossiness", thisMaterial.GetFloat ("_Glossiness"));

		//Color tempColor = fadeMaterial.color;

		//for (float f = tweaks.TransparencyEnablingTime; f >= tweaks.TransparencyValue; f -= 0.1f) {
		//		tempColor.a = f;
		//		fadeMaterial.color = tempColor;
		yield return null;
		//	}
	}


	IEnumerator DisableTransparencyCor(GameObject go){
		go.GetComponent<Collider>().enabled = true;//Activar collider
                                                   /////////////////////////

        ///////////////
        //Material tempMaterial = go.GetComponent<MeshRenderer> ().material;

        //Color tempColor = tempMaterial.color;

        //for (float f = tweaks.TransparencyValue; f <= tweaks.TransparencyDisablingTime; f += 0.1f) {
        //	tempColor.a = f;
        //	tempMaterial.color = tempColor;
        
        //}
        for (int i = 0; i < TransparentGameobjects.Length; i++)
		{
			for (int x = 0; x < TransparentGameobjects[i].GetComponent<MeshRenderer>().materials.Length; x++)
			{
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].color = defaultColor[i];
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].SetInt("_ZWrite", 1);
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].DisableKeyword("_ALPHATEST_ON");
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].DisableKeyword("_ALPHABLEND_ON");
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].DisableKeyword("_ALPHAPREMULTIPLY_ON");
				OpaqueMaterial[i].GetComponent<Renderer>().materials[x].renderQueue = -1;
			}
		}
		yield return null;
	}

	
	void Update () {

		//float CorrectedRPM=RPM * Time.timeScale;
		
		//IntakePhase =elements.CamshaftIntake1.transform.localEulerAngles.z;
		//ExhaustPhase =elements.CamshaftExhaust1.transform.localEulerAngles.z;

		//TimingBeltMaterial.mainTextureOffset += new Vector2 ( 0, CorrectedRPM/85);
		//GeneratorBeltMaterial.mainTextureOffset += new Vector2 (0, CorrectedRPM / 180);

		//elements.Crankshaft.transform.Rotate (new Vector3 (0, 0, CorrectedRPM));

		//elements.CamshaftExhaust1.transform.Rotate (new Vector3 (0, 0, CorrectedRPM/2));
		//elements.CamshaftExhaust2.transform.Rotate (new Vector3 (0, 0, CorrectedRPM/2));
		//elements.CamshaftIntake1.transform.Rotate (new Vector3 (0, 0, CorrectedRPM/2));
		//elements.CamshaftIntake2.transform.Rotate (new Vector3 (0, 0, CorrectedRPM/2));

		//elements.GearboxSecondaryShaft.transform.Rotate (new Vector3 (0, CorrectedRPM*1.47f, 0));
		//elements.GearboxPrimaryShaft.transform.Rotate(new Vector3 (0, -CorrectedRPM,0 ));

		//elements.Gear2.transform.Rotate (new Vector3 (0,0 , -CorrectedRPM*1.47f));
		//elements.Gear3.transform.Rotate (new Vector3 (0,0 , -CorrectedRPM*1.33f));
		//elements.Gear4.transform.Rotate (new Vector3 (0,0 , -CorrectedRPM*0.9996f));
		//elements.Gear5.transform.Rotate (new Vector3 (0,0 , -CorrectedRPM*0.525f));

		//elements.StarterGear1.transform.Rotate(new Vector3 (0,0 , -CorrectedRPM*5.13f));
		//elements.StarterGear2.transform.Rotate(new Vector3 (0,0 , CorrectedRPM*4.8f));

		//elements.TurboFan.transform.Rotate (new Vector3 (0, 0, CorrectedRPM));

		//elements.DistributorGear.transform.Rotate (new Vector3 (0, 0, -CorrectedRPM));

		//elements.TensionPulley.transform.Rotate (new Vector3 (0, 0, -CorrectedRPM));

		//elements.GeneratorPulley.transform.Rotate (new Vector3 (0, -CorrectedRPM*2, 0));
		//elements.WaterPumpPulley.transform.Rotate (new Vector3 (0,0 , -CorrectedRPM*2));

		//elements.Rod1.transform.LookAt (elements.Rod1Target.transform,elements.Rod1.transform.up);
		//elements.Rod2.transform.LookAt (elements.Rod2Target.transform,elements.Rod2.transform.up);
		//elements.Rod3.transform.LookAt (elements.Rod3Target.transform,elements.Rod3.transform.up);
		//elements.Rod4.transform.LookAt (elements.Rod4Target.transform,elements.Rod4.transform.up);

		//Piston1Delta = Rod1DefPos.y - transform.InverseTransformPoint (elements.Rod1.transform.position).y;
		//Piston2Delta = Rod2DefPos.y - transform.InverseTransformPoint (elements.Rod2.transform.position).y;
		//Piston3Delta = Rod3DefPos.y - transform.InverseTransformPoint (elements.Rod3.transform.position).y;
		//Piston4Delta = Rod4DefPos.y - transform.InverseTransformPoint (elements.Rod4.transform.position).y;

		//elements.Piston1.transform.localPosition = Piston1DefPos - new Vector3 (0, Piston1Delta, 0);
		//elements.Piston2.transform.localPosition = Piston2DefPos - new Vector3 (0, Piston2Delta, 0);
		//elements.Piston3.transform.localPosition = Piston3DefPos - new Vector3 (0, Piston3Delta, 0);
		//elements.Piston4.transform.localPosition = Piston4DefPos - new Vector3 (0, Piston4Delta, 0);

		foreach (var valve in elements.intakeValves) {
			float t = 0;

			if (IntakePhase > valve.OpenPhase && IntakePhase < valve.ClosePhase) 
				t = ((IntakePhase - valve.OpenPhase) / (valve.ClosePhase - valve.OpenPhase)) * 2;

			if (t > 1) t = 1 - (t - 1);

			float b = Mathf.SmoothStep (0, 1, t);

			valve.ValveGameobject.transform.localPosition = Vector3.Lerp (valve.DefPos, valve.DefPos - ValveOffset, b);
			valve.SpringGameobject.transform.localScale = Vector3.Lerp (Vector3.one, Vector3.one - ValveSpringOffset, b);
		}

		foreach (var valve in elements.exhaustValves) {
			float t = 0;

			if (ExhaustPhase > valve.OpenPhase && ExhaustPhase < valve.ClosePhase) 
				t = ((ExhaustPhase - valve.OpenPhase) / (valve.ClosePhase - valve.OpenPhase)) * 2;

			if (t > 1) t = 1 - (t - 1);

			float b = Mathf.SmoothStep (0, 1, t);

			valve.ValveGameobject.transform.localPosition = Vector3.Lerp (valve.DefPos, valve.DefPos - ValveOffset, b);
			valve.SpringGameobject.transform.localScale = Vector3.Lerp (Vector3.one, Vector3.one - ValveSpringOffset, b);
		}
	}
}
