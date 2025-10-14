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
    public bool isFilling, isDeFilling, canShowQuestion;
    Image image;
    GameManager gameManager;
    public void UpdateAns(string stuAns)
    {
        this.stuAns = stuAns;
    }
    private void Awake()
    {
        uiManager = FindAnyObjectByType<UIManager>();
        image = GetComponent<Image>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnEnable()
    {
        image.fillAmount = 0;
        canShowQuestion = false;
        isFilling = true;
        isDeFilling = false;
        checkAnsObject.SetActive(false);
        question.gameObject.SetActive(false);
        imageStuAns.color=Color.white;
        stuAns = "";
        imageStuAns.color = Color.white;
        ansField.DeactivateInputField();
        ansField.text = "";
        ansField.ForceLabelUpdate();
    }
    private void Update()
    {
        if (!canShowQuestion)
        {
            if (isFilling)
            {
                image.fillAmount += 0.5f * Time.deltaTime;
            }
            if (image.fillAmount >= 1)
            {
                isFilling = false;
                canShowQuestion = true;
                LoadQuestion();
            }
        };
        if (isDeFilling)
        {
            image.fillAmount -= 0.5f * Time.deltaTime;
            if (image.fillAmount == 0)
            {
                isDeFilling = false;
                gameManager.CheckAfterDefill();
                gameObject.SetActive(false);
            }
        }
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
        question.gameObject.SetActive(true);
        question.text = fillSOs[i].question;
        checkAns = fillSOs[i].answer;
        checkAnsTMP.text=checkAns;
        
    }
    public void CheckAnswer()
    {
        if (stuAns == "")
        {
            FindAnyObjectByType<AudioManager>().ErrorSound();
        }
        else
        {
            FindAnyObjectByType<AudioManager>().ButtonClick1();
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
    public void MakeDeFillingTrue()
    {
        isDeFilling = true;
    }
}
