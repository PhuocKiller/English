using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SentenceController : MonoBehaviour
{
    public MatchQuestionPanel matchQuestionPanel;
    public TextMeshProUGUI textSentence;
    public string stuAns;
    private void Awake()
    {
        matchQuestionPanel= FindAnyObjectByType<MatchQuestionPanel>();
        textSentence=GetComponentInChildren<TextMeshProUGUI>();
    }
    public void OnBeginDrag()
    {
       matchQuestionPanel.mouseFollow.ToggleMouseFollow(true);
      matchQuestionPanel.mouseFollow.ChangeText(this);
        matchQuestionPanel.indexSwap1=transform.GetSiblingIndex();
       GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnEndDrag()
    {
        matchQuestionPanel.mouseFollow.ToggleMouseFollow(false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void OnPointerClick()
    {
        
    }
    public void OnDrop()
    {
        matchQuestionPanel.indexSwap2 = transform.GetSiblingIndex();
        matchQuestionPanel.SwapAnswer();
    }
    public void OnPointerUp()
    {
    }
    public void OnPointerEnter()
    {
        GetComponent<Image>().color = Color.green;
    }
    public void OnPointerExit()
    {
        GetComponent<Image>().color = Color.white;
    }
}
