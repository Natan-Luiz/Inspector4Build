using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Inspector4Build.UnityUI
{
    public class FillComponent : MonoBehaviour
    {
        TextMeshProUGUI title;


        public FillComponent(DataHandle[] data, string _title)
        {
            if (transform.GetChild(1).childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(1).GetChild(i).gameObject);
                }
            }

            title.text = _title;

            for (int i = 0; i < data.Length; i++)
            {
                GameObject go = Instantiate(FillObjectElement.ComponentDataHandleElements[((int)data[i].datatype)], transform.GetChild(1));
            }

            transform.GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 30 * transform.GetChild(1).childCount);
        }

        private void FillData(GameObject go, DataHandle data)
        {
            go.GetComponent<TextMeshProUGUI>().text = data.name;
            switch (data.datatype)
            {
                case CommonType.Int:
                    go.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = data.ViewData();
                    break;
                case CommonType.Double:
                    go.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = data.ViewData();
                    break;
                case CommonType.Float:
                    go.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = data.ViewData();
                    break;
                case CommonType.Vector3:
                    Vector3 v3 = data.GetVerctor3();
                    go.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = v3.x.ToString();
                    go.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = v3.y.ToString();
                    go.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>().text = v3.z.ToString();
                    break;
                case CommonType.String:
                    go.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = data.ViewData();
                    break;
            }
        }
    }
}