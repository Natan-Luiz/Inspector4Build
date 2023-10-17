using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Inspector4Build.UnityUI
{
    public class FillSceneData : MonoBehaviour
    {
        WindowControl wc;
        public TextMeshProUGUI fps;
        public TextMeshProUGUI unity;
        public TextMeshProUGUI scene;
        SceneDetails sd;
        public void OnActivate()
        {
            wc = FindObjectOfType<WindowControl>();
            sd = wc.i4B.GetSceneData();
            fps.text = sd.FrameRate.ToString();
            unity.text = "Unity Version: " + sd.UnityVersion.ToString();
            scene.text = sd.SceneName.ToString();
        }

        private void FixedUpdate()
        {
            fps.text = sd.FrameRate.ToString();
        }
    }
}