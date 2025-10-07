using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class QuestionPanel : MonoBehaviour
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
        Debug.Log($"Chọn câu hỏi thứ {i}");
        question.text = multipleSOs[i].question;
        answerA.text=multipleSOs[i].answerA;
        answerB.text = multipleSOs[i].answerB;
        answerC.text = multipleSOs[i].answerC;
        answerD.text = multipleSOs[i].answerD;
        checkAns = multipleSOs[i].answer;
        stuAns = -1;
        foreach (var item in FindObjectsByType<ButtonManager>(FindObjectsSortMode.None))
        {
            item.isSelected = false; // reset trạng thái logic
            item.SetColor(item.colors.normalColor); // reset màu
        }
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
