using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FillQuestionPanel : MonoBehaviour
{
    public TextMeshProUGUI question,checkAnsTMP;
    public TMP_InputField ansField;
    public string checkAns, stuAns;
    public FillSO[] fillSOs;
    public Image imageStuAns;
    UIManager uiManager;
    public GameObject checkAnsObject;
    private List<int> fillQuestions = new List<int>();
    public void UpdateAns(string stuAns)
    {
        this.stuAns = stuAns;
    }
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
        if (fillQuestions.Count >= fillSOs.Length)
        {
            fillQuestions.Clear();
        }
        int i;
        do
        {
            i = UnityEngine.Random.Range(0, fillSOs.Length);
        }
        while (fillQuestions.Contains(i));

        fillQuestions.Add(i); // lưu lại để lần sau không trùng
        question.text = fillSOs[i].question;
        checkAns = fillSOs[i].answer;
        checkAnsTMP.text=checkAns;
        imageStuAns.color = Color.white;
        checkAnsObject.SetActive(false);
        stuAns = "";
        ansField.DeactivateInputField();
        ansField.text = "";
        ansField.ForceLabelUpdate();
    }
    public void CheckAnswer()
    {
        if (stuAns == "")
        {
            Debug.Log("error");
        }
        else
        {
           uiManager.checkPanel.transform.gameObject.SetActive(true);
           uiManager.checkPanel.CheckAnswer(string.Equals(checkAns.Trim(), stuAns.Trim(), StringComparison.OrdinalIgnoreCase));
           ShowAnswer();
        }
    }

    private void ShowAnswer()
    {
        if (string.Equals(checkAns.Trim(), stuAns.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            imageStuAns.color = Color.green;
        }
        else
        {
            imageStuAns.color = Color.red;
            checkAnsObject.SetActive(true); 
        }
    }
}
