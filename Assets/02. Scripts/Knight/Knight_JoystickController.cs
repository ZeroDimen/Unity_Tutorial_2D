using UnityEngine;
using UnityEngine.EventSystems;

public class Knight_JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Knight_Controller_Joystick knightController;
    [SerializeField] private Knight_Controller_Joystick_Town knightController_Town;
    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    private Vector2 startPos, currPos;

    private void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 100f);

        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;

        if (knightController != null)
        {
            knightController.InputJoystick(dragDir.x, dragDir.y);
        }
        else
        {
            knightController_Town.InputJoystick(dragDir.x, dragDir.y);
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (knightController != null)
        {
            knightController.InputJoystick(0, 0);
        }
        else
        {
            knightController_Town.InputJoystick(0, 0);

        }
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
    }
}
