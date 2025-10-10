using UnityEngine;

public class MatchQuestionPanel : MonoBehaviour
{
    public MouseFollow mouseFollow;
    public SentenceController[] sentences;
    public int indexSwap1, indexSwap2;
    public void SwapAnswer()
    {
        string swapText=sentences[indexSwap1].textSentence.text;
        sentences[indexSwap1].textSentence.text = sentences[indexSwap2].textSentence.text;
        sentences[indexSwap2].textSentence.text=swapText;
        int swapAns = sentences[indexSwap1].stuAns;
        sentences[indexSwap1].stuAns = sentences[indexSwap2].stuAns;
        sentences[indexSwap2].stuAns = swapAns;
    }
    
         
}
