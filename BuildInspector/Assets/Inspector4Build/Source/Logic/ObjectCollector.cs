using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Inspector4Build
{

    /// <summary>
    /// Struct to easily access gameobjects and their parameters
    /// </summary>
    public struct RuntimeObject
    {
        public string name;
        public string uniqueKey;
        public GameObject gameObject;
        public Transform transform;
        public Material material;
        public List<ComponentSystem> components;
        public List<RuntimeObject> childList;
        public int CountComponents { get { return components.Count; } }
    }

    public class ObjectCollector : MonoBehaviour
    {
        private GameObject[] rootRawObjects;
        private RuntimeObject[] hierarchyRootObjects;

        private int numberOfObjects;

        public float TimeSinceCollect { get; private set; }

        public void CollectObjectsInScene()
        {
            rootRawObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            numberOfObjects = FindObjectsOfType<Transform>().Length;
            TimeSinceCollect = 0;
        }

        public void ProcessObjects()
        {
            List<RuntimeObject> fullRuntimeObjectsList = new List<RuntimeObject>();
            List<RuntimeObject> hierarchyRoot = new List<RuntimeObject>();
            foreach (GameObject go in rootRawObjects)
            {
                fullRuntimeObjectsList.AddRange(ProcessObject(go));
                hierarchyRoot.Add(fullRuntimeObjectsList[fullRuntimeObjectsList.Count-1]);
            }


            hierarchyRootObjects = hierarchyRoot.ToArray();
        }

        private List<RuntimeObject> ProcessObject(GameObject go)
        {
            List<RuntimeObject> partialRuntimeObjectsList = new List<RuntimeObject>();

            RuntimeObject obj = new RuntimeObject();
            obj.childList = new List<RuntimeObject>();

            if (go.name != "InspectorWindow") //Don't want to process the Inspecto4Build itself
            {
                for (int i = 0; i < go.transform.childCount; i++)
                {
                    partialRuntimeObjectsList.AddRange(ProcessObject(go.transform.GetChild(i).gameObject));
                    obj.childList.Add(partialRuntimeObjectsList[partialRuntimeObjectsList.Count - 1]);
                }
            }
            
            obj.name = go.name;
            obj.transform = go.transform;
            obj.uniqueKey = FullObjectName(go);
            obj.gameObject = go;
            if (go.GetComponent<MeshRenderer>() != null)
            {
                obj.material = go.GetComponent<MeshRenderer>().material;
            }

            
            obj = ProcessComponents(obj);

            partialRuntimeObjectsList.Add(obj);

            return partialRuntimeObjectsList;
        }

        private RuntimeObject ProcessComponents(RuntimeObject obj)
        {
            Component[] components =  obj.gameObject.GetComponents<Component>();
            obj.components = new List<ComponentSystem>();
            for(int i = 0; i < components.Length; i++)
            {
                System.Type t = components[i].GetType();

                if (t == typeof(Transform) ||
                    t == typeof(Material) ||
                    t == typeof(MeshFilter) ||
                    t == typeof(MeshRenderer) )
                {
                    // Do nothing 
                }
                else
                {
                    obj.components.Add(ComponentSystem.GetComponent(components[i]));
                }
            }
            return obj;
        }

        private string FullObjectName(GameObject go)
        {
            string s = "";
            Transform t = go.transform;
            while(t != null)
            {
                s = $"{t.gameObject.name}.{s}";
                t = t.parent;
            }
            return s;
        }

        public RuntimeObject[] GetObjectsInScene(bool update = false)
        {
            if (update)
            {
                CollectObjectsInScene();
                ProcessObjects();
            }
            else if (hierarchyRootObjects == null || hierarchyRootObjects.Length <= 0)
            {
                throw new System.ArgumentException("Object Collection Error: Objects were not collected yet.");
            }
            return hierarchyRootObjects;
        }
    }
}