using TMPro;
using UnityEngine;

public class CheckWinPanel : MonoBehaviour
{
    public TextMeshProUGUI informTMP;
    public bool trueFalse;
    public UIManager uIManager;
    public int rightAnswers;
    GameManager gameManager;

    private void Awake()
    {
        uIManager=FindAnyObjectByType<UIManager>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    public void ShowMessage(int rightAnswers)
    {
        informTMP.text = $"You have {rightAnswers}/4 correct answers";
        this.rightAnswers = rightAnswers;
        gameManager.trueFalse = rightAnswers == 4;
    }
    public void Continue()
    {

        if (rightAnswers == 4)
        {
          //  FindAnyObjectByType<GameManager>().PlayerMove();
        }
        else
        {

          //  FindAnyObjectByType<GameManager>().ActivePlayer();
            
        }
        FindAnyObjectByType<MatchQuestionPanel>().checkMatch[0].transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
