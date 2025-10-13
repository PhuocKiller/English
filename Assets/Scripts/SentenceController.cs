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
        
    }
    public void OnBeginDrag()
    {
        if (!matchQuestionPanel.canInteract) return;
       matchQuestionPanel.mouseFollow.ToggleMouseFollow(true);
      matchQuestionPanel.mouseFollow.ChangeText(this);
        matchQuestionPanel.indexSwap1=transform.GetSiblingIndex();
       GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnEndDrag()
    {
        if (!matchQuestionPanel.canInteract) return;
        matchQuestionPanel.mouseFollow.ToggleMouseFollow(false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void OnPointerClick()
    {
        
    }
    public void OnDrop()
    {
        if (!matchQuestionPanel.canInteract) return;
        matchQuestionPanel.indexSwap2 = transform.GetSiblingIndex();
        matchQuestionPanel.SwapAnswer();
        FindAnyObjectByType<AudioManager>().ButtonClick1();
    }
    public void OnPointerUp()
    {
    }
    public void OnPointerEnter()
    {
        if (!matchQuestionPanel.canInteract) return;
        GetComponent<Image>().color = Color.green;
    }
    public void OnPointerExit()
    {
        if (!matchQuestionPanel.canInteract) return;
        GetComponent<Image>().color = Color.white;
    }
}
