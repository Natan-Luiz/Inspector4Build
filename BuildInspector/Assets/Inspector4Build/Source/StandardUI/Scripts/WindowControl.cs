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
        public RuntimeObject currentObject;


        private void Awake()
        {
            i4B = new Inspector4Build();
            i4B.Initialize();
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
