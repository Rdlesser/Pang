using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Utils
{
    public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public UnityEvent onLongClick;

        private bool _pointerDown;


        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pointerDown = false;
        }

        private void Update()
        {
            if (_pointerDown)
            {
                onLongClick.Invoke();
            }
        }

    }
}