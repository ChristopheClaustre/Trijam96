using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class OpenURL : MonoBehaviour
{
    public void Open(string url)
    {
        #if (UNITY_WEBGL && !UNITY_EDITOR)
            openWindow(url);
        #else
            Application.OpenURL(url);
        #endif
    }

#if UNITY_WEBGL
    [DllImport("__Internal")]
	private static extern void openWindow(string url);
#endif
}
