using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    private void Awake()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }
    public void PlayerMove()
    {
        playerController.animator.SetTrigger("hello");
       // playerController.isMoving = true;
    }
    public void ActivePlayer()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(playerController.transform.position, 1f);
        foreach (Collider collider in hitColliders)
        {
            BlockManager block = collider.GetComponent<BlockManager>();
            if (block != null)
            {
                playerController.myPos = new Vector3Int(block.posX, 0, block.posZ);
                break;
            }
        }
        if (playerController.lives>1)
        {
            playerController.canInteract = true;
        }
        playerController.LostHealth();
    }
}
