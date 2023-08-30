using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    private Button Click;
    // public bool bandera=false;
    
    // Start is called before the first frame update
    void Start()
    {
        Click = gameObject.GetComponent<Button>();
    }
    // public void Update() {
    //     if(bandera=true)
    //     {
    //         TaskOnClick();

    //     }
    // }

    // Update is called once per frame
   public void TaskOnClick(){
		Click.onClick.Invoke();
	}
}
