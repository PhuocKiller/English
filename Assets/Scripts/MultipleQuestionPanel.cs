using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class MultipleQuestionPanel : MonoBehaviour
{
    public int checkAns, stuAns;
    UIManager uiManager;
    public ButtonManager[] buttons;
    public MultipleSO[] multipleSOs;
    public TextMeshProUGUI question,answerA, answerB,answerC,answerD;
    private List<int> multipleQuestions = new List<int>();
    private void Awake()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }
    private void OnEnable()
    {
        LoadQuestion();
        for (int j = 0; j < buttons.Length; j++)
        {
            buttons[j].GetComponent<Button>().interactable = false;
        }
        answerA.gameObject.SetActive(false);
        answerB.gameObject.SetActive(false);
        answerC.gameObject.SetActive(false);
        answerD.gameObject.SetActive(false);
    }

    private void LoadQuestion()
    {
        if (multipleQuestions.Count >= multipleSOs.Length)
        {
            multipleQuestions.Clear();  
        }
        int i;
        do
        {
            i = UnityEngine.Random.Range(0, multipleSOs.Length);
        }
        while (multipleQuestions.Contains(i));

        multipleQuestions.Add(i); // lưu lại để lần sau không trùng
        //question.text = multipleSOs[i].question;
        
        StartCoroutine(ShowTextDelay(question, multipleSOs[i].question,i));
        checkAns = multipleSOs[i].answer;
        stuAns = -1;
        foreach (var item in FindObjectsByType<ButtonManager>(FindObjectsSortMode.None))
        {
            item.isSelected = false; // reset trạng thái logic
            item.SetColor(item.colors.normalColor); // reset màu
        }
    }
    IEnumerator ShowTextDelay(TextMeshProUGUI textTMP, string soText, int i)
    {
        textTMP.text = soText;
        yield return new WaitForSeconds(5);
        ShowAnswer(i);
    }
    public void ShowAnswer(int i)
    {
        for (int j = 0; j < buttons.Length; j++)
        {
            buttons[j].GetComponent<Button>().interactable = true;
        }
        answerA.gameObject.SetActive(true);
        answerA.text = multipleSOs[i].answerA;
        answerB.gameObject.SetActive(true);
        answerB.text = multipleSOs[i].answerB;
        answerC.gameObject.SetActive(true);
        answerC.text = multipleSOs[i].answerC;
        answerD.gameObject.SetActive(true);
        answerD.text = multipleSOs[i].answerD;
    }

    public void CheckAnswer()
    {
        if (stuAns == -1)
        {
            Debug.Log("error");
        }
        else
        {
            uiManager.checkPanel.transform.gameObject.SetActive(true);
            uiManager.checkPanel.CheckAnswer(checkAns == stuAns);
            ShowAnswer();
        }
    }
    public void ShowAnswer()
    {
        buttons[stuAns].SetColor(Color.red);
        buttons[checkAns].SetColor(Color.green);
    }
}
