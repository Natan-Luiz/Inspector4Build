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
        GameObject storedObject;

        private void Awake()
        {
            ComponentDataHandleElements = componentDataHandleElement;
        }

        public void OnActivate()
        {
            if(transform.childCount > 0)
            {
                for(int i = 0; i < transform.childCount; i++) 
                { 
                    Destroy(transform.GetChild(i).gameObject);
                }
            }

            wc = FindObjectOfType<WindowControl>();
            RuntimeObject obj = wc.currentObject;

            if (obj.gameObject == null)
                return;

            storedObject = obj.gameObject;
            float position = 0;

            GameObject trnsf = Instantiate(componentElement, transform);
            trnsf.GetComponent<FillComponent>().FillData(ComponentHandler.ProcessComponent(obj.transform),"Transform");
            trnsf.transform.localPosition = Vector3.up * position;
            storedTransform = trnsf;
            position -= trnsf.GetComponent<FillComponent>().GetSize();

           for (int i = 0; i < obj.components.Count; i++)
           {
                GameObject go = Instantiate(componentElement, transform);
                go.GetComponent<FillComponent>().FillData(null, obj.components[i].name);
                go.transform.localPosition = Vector3.up * position;
                position -= go.GetComponent<FillComponent>().GetSize();
            }

           if(obj.material != null)
           {
                GameObject mtt = Instantiate(componentElement, transform);
                mtt.GetComponent<FillComponent>().FillData(ComponentHandler.ProcessComponent(obj.material), "Material");
                mtt.transform.localPosition = Vector3.up * position;
            }
        }

        public void UpdateTransform()
        {
            if (storedTransform != null)
            {
                storedTransform.GetComponent<FillComponent>().FillData(ComponentHandler.ProcessComponent(storedObject.transform), "Transform");
            }
        }

        void Update()
        {
            UpdateTransform();
        }
    }
}