using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("LastScore");
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.Save();
    }
#endif
}
