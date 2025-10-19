using System.Runtime.InteropServices;
using UnityEngine;

public class FullscreenManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ToggleFullScreen();

    public void OnToggleFullscreen()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ToggleFullScreen();
#else
        Screen.fullScreen = !Screen.fullScreen;
#endif
    }
}
