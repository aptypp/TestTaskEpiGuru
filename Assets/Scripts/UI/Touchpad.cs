using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.UI
{
    public class Touchpad : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public event Action<float> PositionChanged;

        public void OnPointerDown(
            PointerEventData eventData)
        {
            var positionX = eventData.position.x / Screen.width;

            PositionChanged?.Invoke(positionX);
        }

        public void OnDrag(
            PointerEventData eventData)
        {
            var positionX = eventData.position.x / Screen.width;

            PositionChanged?.Invoke(positionX);
        }
    }
}