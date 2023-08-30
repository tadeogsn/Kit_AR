using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSet : MonoBehaviour
{
    public int StartWidth;
    public int StartHeight;
    public int TargetWidth;
    public int TargetHeight;

    public KeyCode ButtonChangeResolution;
    // Start is called before the first frame update
    void SetResolution()
    {
        Screen.SetResolution(TargetWidth, TargetHeight, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(ButtonChangeResolution)){

                SetResolution();
        }
    }
}
