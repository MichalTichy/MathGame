using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

	public void ExitGame()
    {
        #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }
}
