using UnityEngine;

[CreateAssetMenu(menuName = "QuestionSystem/Create Match Question Data")]
public class MatchSO: ScriptableObject
{
    public string[] left, right;
    public string[] checkAns;
}
