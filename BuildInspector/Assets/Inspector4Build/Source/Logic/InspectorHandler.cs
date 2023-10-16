using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inspector4Build
{
    public class InspectorHandler : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Component[] components = GetComponents<Component>();

            foreach (Component comp in components)
            {
                Debug.Log(comp.GetType());

                if(comp.GetType() == typeof(Behaviour))
                {
                    Debug.LogWarning("Achou");
                }
               /* if (((MonoBehaviour)comp) != null)
                {
                   // if(((Behaviour)comp).isActiveAndEnabled)
                   //     Debug.LogError("Ok");
                }*/
            }


        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}