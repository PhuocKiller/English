using UnityEngine;


[CreateAssetMenu(menuName = "QuestionSystem/Create Question Data")]
public class MultipleSO: ScriptableObject
{
    public string question;
    public string answerA;
    public string answerB;
    public string answerC;
    public string answerD;
    public int answer;
}
