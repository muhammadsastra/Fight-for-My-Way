using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystickku : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image bgJoystick;
    private Image handle;
    private float offset = 2.1f;
    public Vector2 InputDir { set; get; }

    private void Start()
    {
        bgJoystick = GetComponent<Image>();
        handle = transform.GetChild(0).GetComponent<Image>();
        InputDir = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputDir = Vector2.zero;
        handle.rectTransform.anchoredPosition = Vector2.zero;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = Vector2.zero;
        float bgimageSizeX = bgJoystick.rectTransform.sizeDelta.x;
        float bgimageSizeY = bgJoystick.rectTransform.sizeDelta.y;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgJoystick.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= bgimageSizeX;
            pos.y /= bgimageSizeY;
            InputDir = new Vector2(pos.x, pos.y);
            InputDir = InputDir.magnitude > 1 ? InputDir.normalized : InputDir;
            handle.rectTransform.anchoredPosition = new Vector2(InputDir.x * (bgimageSizeX / offset), InputDir.y * (bgimageSizeY / offset));
        }
           
    }
}
