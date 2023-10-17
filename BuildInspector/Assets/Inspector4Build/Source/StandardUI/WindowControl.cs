using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inspector4Build.UnityUI
{
    public class WindowControl : MonoBehaviour
    {

        void Update()
        {
            KeyboardShortcuts();
        }

        private void KeyboardShortcuts()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.I)) // CTRL + I -> Start Tool
            {
                Debug.Log("Shortcut not implemented yet");
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
                Debug.Log("Shortcut not implemented yet");
            }

        }
    }
}
