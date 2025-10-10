using TMPro;
using UnityEngine;

public class SentenceController : MonoBehaviour
{
    public MatchQuestionPanel matchQuestionPanel;
    public TextMeshProUGUI textSentence;
    public int stuAns;
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
        Debug.Log("onbegindrag");
    }
    public void OnEndDrag()
    {
        matchQuestionPanel.mouseFollow.ToggleMouseFollow(false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("onenddrag");
    }
    public void OnPointerClick()
    {
        
        Debug.Log("pointerclick");
    }
    public void OnDrop()
    {
        matchQuestionPanel.indexSwap2 = transform.GetSiblingIndex();
        matchQuestionPanel.SwapAnswer();
    }
    public void OnPointerUp()
    {
        Debug.Log("pointerup");
    }
}
