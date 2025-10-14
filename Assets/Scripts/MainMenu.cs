using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool isFilling, isDeFilling, canShowQuestion;
    Image image;
    GameManager gameManager;
    private void Awake()
    {
        image = GetComponent<Image>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    private void OnEnable()
    {
        image.fillAmount = 1;
        canShowQuestion = false;
        isFilling = true;
        isDeFilling = false;
    }
    private void Update()
    {
        /*if (!canShowQuestion)
        {
            if (isFilling)
            {
                image.fillAmount += 0.5f * Time.deltaTime;
            }
            if (image.fillAmount >= 1)
            {
                isFilling = false;
                canShowQuestion = true;
            }
        };*/
        if (isDeFilling)
        {
            image.fillAmount -= 0.5f * Time.deltaTime;
            if (image.fillAmount == 0)
            {
                isDeFilling = false;
                gameManager.CreatePlayer();
                gameObject.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        isDeFilling = true;
    }
}
