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
        public GameObject componentElement;

        public List<GameObject> componentDataHandleElement;
        public static List<GameObject> ComponentDataHandleElements;

        GameObject storedTransform;

        private void Awake()
        {
            ComponentDataHandleElements = componentDataHandleElement;
        }

        public void OnActivate()
        {
            wc = FindObjectOfType<WindowControl>();
            RuntimeObject obj = wc.currentObject;

           

           for(int i = 0; i < obj.components.Count; i++)
           {
                GameObject go = Instantiate(componentElement);

           }
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