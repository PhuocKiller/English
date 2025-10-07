using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CheckPanel : MonoBehaviour
{
    public TextMeshProUGUI informTMP;
    public bool trueFalse;
    public GameManager gameManager;
    public void CheckAnswer(bool trueFalse)
    {
       ShowMessage(trueFalse);
        this.trueFalse = trueFalse;
    }
    public void ShowMessage(bool trueFalse)
    {
        informTMP.text = trueFalse ? "You are right" : "You are wrong";
    }
    public void Continue()
    {

       if(trueFalse)
        {
            gameManager.PlayerMove();
        }
       else
        {
            gameManager.ActivePlayer();
        }
       gameObject.SetActive(false);
    }
}
