using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    public bool isMoving;
    public bool canInteract;
    Vector3 destinationPoint, direction;
    Ray ray; RaycastHit hit;
    BlockManager[] blocks;
    public Vector3Int myPos;
    public AllBlocksManager allBlocksManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       characterController = GetComponent<CharacterController>();
       animator = GetComponent<Animator>();
       blocks = FindObjectsByType<BlockManager>(FindObjectsSortMode.InstanceID);
       myPos=new Vector3Int(0,0,0);
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
        if (Input.GetMouseButtonDown(1)) canInteract = true;
        if (canInteract)
        {   
            if (Physics.Raycast(ray, out hit) )
            {
                BlockManager block = hit.transform.GetComponent<BlockManager>();
                if (Input.GetMouseButtonDown(0) && block!= null && (block.posX + block.posZ - myPos.x - myPos.z) == 1)
                {
                    destinationPoint = new Vector3(hit.transform.position.x, 0, hit.transform.position.z);
                    myPos = new Vector3Int(block.posX, 0, block.posZ);
                    isMoving = true;
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
            allBlocksManager.DestroyBlocks(myPos.x, myPos.z);   
        }
    }
}
