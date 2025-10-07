using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonManager : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler,
    IPointerDownHandler, IPointerUpHandler
{
    private Button btn;
    private Graphic targetGraphic;
    public ColorBlock colors;
    private bool isPointerDown = false;
    public bool isSelected = false;
    private bool pointerInside = false;
    public int index;

    void Awake()
    {
        btn = GetComponent<Button>();
        targetGraphic = btn.targetGraphic;
        colors = btn.colors;
        index=transform.GetSiblingIndex();
    }

    void Update()
    {
        if (isPointerDown)
        {
            bool inside = RectTransformUtility.RectangleContainsScreenPoint(
                btn.GetComponent<RectTransform>(),
                Input.mousePosition,
                GetCanvasCamera());

            // Nếu đang giữ chuột và rê ra ngoài -> bỏ chọn và reset màu
            if (!inside && pointerInside)
            {
                pointerInside = false;
                isSelected = false;
                SetColor(colors.normalColor);
            }
            // Nếu đang giữ chuột và rê vào lại -> pressed lại
            else if (inside && !pointerInside)
            {
                pointerInside = true;
                SetColor(colors.pressedColor);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!btn.interactable) return;
        pointerInside = true;

        if (isPointerDown)
            SetColor(colors.pressedColor);
        else if (isSelected)
            SetColor(colors.selectedColor);
        else
            SetColor(colors.highlightedColor);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!btn.interactable) return;
        pointerInside = false;

        if (!isPointerDown)
        {
            if (isSelected)
                SetColor(colors.selectedColor);
            else
                SetColor(colors.normalColor);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!btn.interactable) return;
        isPointerDown = true;
        pointerInside = true;
        SetColor(colors.pressedColor);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!btn.interactable) return;
        isPointerDown = false;

        bool inside = RectTransformUtility.RectangleContainsScreenPoint(
            btn.GetComponent<RectTransform>(),
            eventData.position,
            GetCanvasCamera());

        pointerInside = inside;

        if (inside)
        {
            // Click hợp lệ -> chọn
            isSelected = true;
            foreach (var item in FindObjectsByType<ButtonManager>(FindObjectsSortMode.None))
            {
                item.isSelected = false; // reset trạng thái logic
                item.SetColor(item.colors.normalColor); // reset màu
            }
            isSelected = true;
            SetColor(colors.selectedColor);
            FindAnyObjectByType<QuestionPanel>().stuAns=index;
        }
        else
        {
            // Thả ra ngoài -> không chọn
            isSelected = false;
            SetColor(colors.normalColor);
        }
    }

    public void SetColor(Color c)
    {
        if (targetGraphic != null)
            targetGraphic.color = c;
    }

    private Camera GetCanvasCamera()
    {
        Canvas c = GetComponentInParent<Canvas>();
        return c != null ? c.worldCamera : null;
    }
}


