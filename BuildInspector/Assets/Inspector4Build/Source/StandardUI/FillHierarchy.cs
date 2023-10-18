using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


namespace Inspector4Build.UnityUI
{

    public class FillHierarchy : MonoBehaviour
    {
        public GameObject clickableElement;
        private int counter = 0;
        WindowControl wc;


        // Start is called before the first frame update
        public void OnActivate()
        {
           for(int i = 0; i< transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
                counter = 0;
            }
           
            wc = FindObjectOfType<WindowControl>();
            RuntimeObject[] objs = wc.i4B.GetHierarchy();

            for (int i = 0; i < objs.Length; i++)
            {
                CreateObject(0, objs[i]);
            }

            GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 30 * transform.childCount);
        }

        public void CreateObject(int lvl, RuntimeObject obj)
        {
            GameObject go = Instantiate(clickableElement, transform);
            go.transform.position = new Vector3(go.transform.position.x + lvl * 15, go.transform.position.y + counter * -30, 0);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = obj.name;
            counter++;

            for (int i = 0; i < obj.childList.Count; i++)
            {
                CreateObject(lvl + 1, obj.childList[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}