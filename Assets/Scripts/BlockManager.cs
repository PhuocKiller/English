using UnityEngine;

public enum QuestionType
{
    Multiple,
    Fill,
    Match
}
public class BlockManager : MonoBehaviour
{
    public bool isChosing;
    public int posX,posZ;
    public Material mat1, mat2;
    public QuestionType questionType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posX=(int)transform.position.x==0?0 : (int)transform.position.x==5?1 : 2;
        posZ = (int)transform.position.z == 0 ? 0 : (int)transform.position.z == 5 ? 1 : 2;
        int sum=posX+posZ;
        if(sum % 2==0)
        {
            questionType = QuestionType.Multiple;
        }
        else
        {
            questionType = QuestionType.Fill;
        }
        if (sum==4) { questionType = QuestionType.Match; }
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material = isChosing ? mat2:mat1;
    }
}
