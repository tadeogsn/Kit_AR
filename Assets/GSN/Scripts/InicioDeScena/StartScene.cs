using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public GameObject canvasGeneral;
    public bool bandera;
    // Start is called before the first frame update
    void Awake()
    {
         Screen.orientation = ScreenOrientation.LandscapeLeft;//orientacion del celular en este caso a la izquierda
        ///
    }

    // Update is called once per frame
    void Update()
    {
        if(Screen.orientation==ScreenOrientation.LandscapeLeft&&bandera==false){
            canvasGeneral.SetActive(true);
            bandera=true;
        }
         
    }
}
