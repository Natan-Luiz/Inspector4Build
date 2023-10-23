using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Inspector4Build
{

    public class SceneDetails
    {
        public int FrameRate { get { return (int)(1f / Time.deltaTime); } }
        public string SceneName { get { return SceneManager.GetActiveScene().name; } }
        public string UnityVersion { get { return Application.unityVersion; } }

        public int CountObjects { get; set; }
        public int CountActiveObjects { get; set; }
    }
}
