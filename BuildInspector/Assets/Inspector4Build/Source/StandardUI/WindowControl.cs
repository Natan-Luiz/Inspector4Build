using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inspector4Build.UnityUI
{
    public class WindowControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        Vector3 posDiff;
        public Inspector4Build i4B;

        private void Start()
        {
            i4B = new Inspector4Build();
            i4B.Initialize();
        }

        void Update()
        {
            KeyboardShortcuts();
        }

        private void KeyboardShortcuts()
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.I)) // CTRL + I -> Start Tool
            {
                Debug.Log("Shortcut not implemented yet");
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.X)) // CTRL + X -> Stop Tool
            {
                Debug.Log("Shortcut not implemented yet");
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.L)) // CTRL + L -> Show Tool
            {
                Debug.Log("Shortcut not implemented yet");
            }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.H)) // CTRL + H -> Hide Tool
            {
                Debug.Log("Shortcut not implemented yet");
            }

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            posDiff = transform.position - new Vector3(eventData.position.x, eventData.position.y, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = new Vector3(eventData.position.x, eventData.position.y, 0) + posDiff;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = new Vector3(eventData.position.x, eventData.position.y, 0) + posDiff;
        }
    }
}
