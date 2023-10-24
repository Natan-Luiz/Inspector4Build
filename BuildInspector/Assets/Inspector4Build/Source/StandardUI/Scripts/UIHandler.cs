using Inspector4Build.UnityUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public WindowControl wc;
    public Button shortcut;



    void Update()
    {
        KeyboardShortcuts();
    }

    private void KeyboardShortcuts()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.I)) // CTRL + I -> Start Tool
        {
            wc.gameObject.SetActive(true);
            shortcut.gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.X)) // CTRL + X -> Stop Tool
        {
            Debug.Log("Shortcut not implemented yet");
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.L)) // CTRL + L -> Show Tool
        {
            Debug.Log("Shortcut not implemented yet");
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.H)) // CTRL + H -> Hide Tool
        {
            wc.gameObject.SetActive(false);
            shortcut.gameObject.SetActive(true);
        }

    }
}
