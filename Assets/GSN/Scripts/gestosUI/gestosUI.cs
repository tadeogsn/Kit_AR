using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gestosUI : MonoBehaviour
{
    //public GameObject objeto;

    public string nombreDeLaEscena;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().buildIndex == 0){
                SceneManager.LoadScene(nombreDeLaEscena);
                Screen.orientation = ScreenOrientation.LandscapeLeft;//este lo suso para el caso exacto de la Scena MENU
            }
                
            else
                SceneManager.LoadScene(0);
        }
    }
}
