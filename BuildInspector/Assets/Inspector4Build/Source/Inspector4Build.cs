using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

namespace Inspector4Build
{
    public class Inspector4Build
    {
        SceneDetails sceneDetails;
        InspectorHandler inspectorHandler;
        ObjectCollector collector;

        Thread work;
        bool constantUpdate;

        public void Initialize()
        {
            collector = new ObjectCollector();
            sceneDetails = new SceneDetails();
            inspectorHandler = new InspectorHandler();
        }

        public void GetSceneDataAsync()
        {
            if(work == null || !work.IsAlive)
            {
                work = new Thread(CollectDataTask);
                work.Start();
            }
        }

        public void CollectDataTask()
        {
            collector.CollectObjectsInScene();
        }

        public RuntimeObject[] GetHierarchy()
        {
            return collector.GetObjectsInScene(true);
        }

        public SceneDetails GetSceneData()
        {
            return sceneDetails;
        }
    }

}