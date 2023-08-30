using UnityEngine;
using Vuforia;

public class CameraFocus : MonoBehaviour

{
    private VuforiaARController vuforiaController;

    void Start()
    {
        vuforiaController = VuforiaARController.Instance;

        if (vuforiaController != null)
        {
            vuforiaController.RegisterVuforiaStartedCallback(OnVuforiaStarted);
            vuforiaController.RegisterOnPauseCallback(OnPaused);
        }
    }

    void OnVuforiaStarted()
    {
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    void OnPaused(bool paused)
    {
        if (!paused)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}