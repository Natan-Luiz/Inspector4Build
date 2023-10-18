using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

namespace Inspector4Build.UnityUI
{
    public class FillObjectElement : MonoBehaviour
    {
        WindowControl wc;

        public void OnActivate()
        {
            wc = FindObjectOfType<WindowControl>();
            RuntimeObject obj = wc.currentObject;

            

        }

        public void UpdateTransform()
        {

        }

        void Update()
        {
            UpdateTransform();
        }
    }
}