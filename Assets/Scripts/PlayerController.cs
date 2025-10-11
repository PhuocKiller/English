using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public Animator animator;
    public bool isMoving;
    public bool canInteract;
    Vector3 destinationPoint, direction;
    Ray ray; RaycastHit hit;
    BlockManager[] blocks;
    public Vector3Int myPos;
    AllBlocksManager allBlocksManager;
    AllBridgesManager allBridgesManager;
    public UIManager uiManager;
    public int lives = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       characterController = GetComponent<CharacterController>();
       animator = GetComponent<Animator>();
       blocks = FindObjectsByType<BlockManager>(FindObjectsSortMode.InstanceID);
       myPos=new Vector3Int(0,0,0);
        allBlocksManager=FindAnyObjectByType<AllBlocksManager>();
       allBridgesManager = FindAnyObjectByType<AllBridgesManager>();
        canInteract = true;
        uiManager.UpdateHealth(lives);
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        foreach (var item in blocks)
        {
            item.isChosing = false;
        }
        if (Physics.Raycast(ray, out hit))
        {
            BlockManager block = hit.transform.GetComponent<BlockManager>();
            if (block != null &&(block.posX +block.posZ- myPos.x - myPos.z)==1)
            {
                block.isChosing = true;
            }
        }
        //if (Input.GetMouseButtonDown(1)) canInteract = true;
        if (canInteract)
        {   
            if (Physics.Raycast(ray, out hit) )
            {
                BlockManager block = hit.transform.GetComponent<BlockManager>();
                if (Input.GetMouseButtonDown(0) && block!= null && (block.posX + block.posZ - myPos.x - myPos.z) == 1)
                {
                    destinationPoint = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                    myPos = new Vector3Int(block.posX, 0, block.posZ);
                    ShowPanelQuestion(CheckQuestionType(block));
                   canInteract = false;
                }
            }
        }
        else
        {
           if(!isMoving) transform.forward = Vector3.Slerp(transform.forward, new Vector3(0, 0, -1), 5 * Time.deltaTime);
        }
        if (isMoving) CalculateMove();
    }
    void CalculateMove()
    {
        animator.SetBool("isWalk", true);
        direction = destinationPoint - new Vector3(transform.position.x, 0, transform.position.z);
        if (direction.magnitude > 0.05f)
        {
            characterController.Move(direction.normalized * 5f * Time.deltaTime);
            transform.forward = Vector3.Slerp(transform.forward, direction, 5 * Time.deltaTime);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isWalk", false);
            StartCoroutine(DelayBeforeGoing());
        }
    }
    IEnumerator DelayBeforeGoing()
    {
        yield return new WaitForSeconds(1f);
        canInteract = true;
        allBlocksManager.DestroyBlocks(myPos.x, myPos.z);
        allBridgesManager.DestroyBridges(myPos.x, myPos.z);
        CheckWin(myPos);
    }
    public IEnumerator DelayInteract()
    {
        yield return new WaitForSeconds(1f);
        canInteract = true;
    }

    public QuestionType CheckQuestionType(BlockManager block)
    {
        int sum = block.posX + block.posZ;
        if (sum == 4) { return QuestionType.Match; }
        else if (sum % 2 == 0)
        {
            return QuestionType.Multiple;
        }
        else
        {
            return QuestionType.Fill;
        }
        
    }
    public void ShowPanelQuestion(QuestionType questionType)
    {
        FindAnyObjectByType<UIManager>().transform.GetChild
            (questionType==QuestionType.Multiple?2: questionType == QuestionType.Fill? 3: 4).gameObject.SetActive(true);
    }
    private void CheckWin(Vector3 pos)
    {
        if(pos==new Vector3(2, 0, 2))
        {
            uiManager.winPanelManager.transform.gameObject.SetActive(true);
        }
    }
    public void LostHealth()
    {
        lives -= 1;
        uiManager.UpdateHealth(lives);
        animator.SetTrigger("damaged");
    }
}
