using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class MatchQuestionPanel : MonoBehaviour
{
    public MouseFollow mouseFollow;
    public SentenceController[] sentences;
    public GameObject[] leftMatch, checkMatch, checkAns; 
    public int indexSwap1, indexSwap2;
    public MatchSO[] matchSOs;
    private List<int> matchQuestions = new List<int>();
    public Sprite checkSpriteTrue, checkSpriteFalse;
    public CheckWinPanel checkWinPanel;
    public void SwapAnswer()
    {
        string swapText=sentences[indexSwap1].textSentence.text;
        sentences[indexSwap1].textSentence.text = sentences[indexSwap2].textSentence.text;
        sentences[indexSwap2].textSentence.text=swapText;
        string swapAns = sentences[indexSwap1].stuAns;
        sentences[indexSwap1].stuAns = sentences[indexSwap2].stuAns;
        sentences[indexSwap2].stuAns = swapAns;
    }
    private void Awake()
    {
    }
    private void OnEnable()
    {
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        if (matchQuestions.Count >= matchSOs.Length)
        {
            matchQuestions.Clear();
        }
        int i;
        do
        {
            i = UnityEngine.Random.Range(0, matchSOs.Length);
        }
        while (matchQuestions.Contains(i));

        matchQuestions.Add(i); // lưu lại để lần sau không trùng
        for (int j=0; j<4; j++)
        {
            leftMatch[j].GetComponentInChildren<TextMeshProUGUI>().text = matchSOs[i].left[j];
            sentences[j].GetComponentInChildren<TextMeshProUGUI>().text = matchSOs[i].right[j];
            int indexSen = sentences[j].transform.GetSiblingIndex();
            sentences[j].stuAns = indexSen == 0 ? "A" : indexSen == 1 ? "B" : indexSen == 2 ? "C" : "D";
            checkAns[j].GetComponent<TextMeshProUGUI>().text = matchSOs[i].checkAns[j];
        }
    }
    public void FinishBtn()
    {
        checkWinPanel.gameObject.SetActive(true);
        int rightAnswers = 0;
        checkMatch[0].transform.parent.gameObject.SetActive(true);
        for (int j = 0; j < 4; j++)
        {
            checkMatch[j].SetActive(true);
            bool trueFalse = sentences[j].stuAns == checkAns[j].GetComponent<TextMeshProUGUI>().text;
            checkMatch[j].GetComponent<Image>().sprite= trueFalse? checkSpriteTrue : checkSpriteFalse;
            checkMatch[j].transform.GetChild(0).GetComponent<Image>().color = trueFalse ? Color.green : Color.red;
            checkMatch[j].GetComponent<Image>().color = trueFalse ? Color.green : Color.red;
            if (trueFalse)
            {
                rightAnswers++;
            };
        }
        checkWinPanel.ShowMessage(rightAnswers);
    }
}
