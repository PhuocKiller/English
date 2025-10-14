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
        gameManager.trueFalse = trueFalse;
    }
    public void ShowMessage(bool trueFalse)
    {
        informTMP.text = trueFalse ? "You are right" : "You are wrong";
    }
    
}
