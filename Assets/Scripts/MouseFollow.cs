using TMPro;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI textMouseFollow;
    private void Awake()
    {
        canvas=transform.root.GetComponent<Canvas>();
        textMouseFollow=GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,Input.mousePosition,
            canvas.worldCamera, out position);
        transform.position= canvas.transform.TransformPoint(position);
    }
    public void ToggleMouseFollow(bool toggle)
    {
       gameObject.SetActive(toggle);
    }
    public void ChangeText(SentenceController text)
    {
        textMouseFollow.text= text.textSentence.text;
    }
}
