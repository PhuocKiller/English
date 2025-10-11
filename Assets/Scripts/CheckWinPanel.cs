using TMPro;
using UnityEngine;

public class CheckWinPanel : MonoBehaviour
{
    public TextMeshProUGUI informTMP;
    public bool trueFalse;
    public UIManager uIManager;
    public int rightAnswers;

    private void Awake()
    {
        uIManager=FindAnyObjectByType<UIManager>();
    }
    public void ShowMessage(int rightAnswers)
    {
        informTMP.text = $"You have {rightAnswers}/4 correct answers";
        this.rightAnswers = rightAnswers;
    }
    public void Continue()
    {

        if (rightAnswers==4)
        {
            uIManager.winPanelManager.gameObject.SetActive(true);
            FindAnyObjectByType<PlayerController>().animator.SetTrigger("dance");
        }
        else
        {

            FindAnyObjectByType<GameManager>().ActivePlayer();
            FindAnyObjectByType<MatchQuestionPanel>().checkMatch[0].transform.parent.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }
}
