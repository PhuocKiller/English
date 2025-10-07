using UnityEngine;

public class AllBlocksManager : MonoBehaviour
{
    public BlockManager[] blocks;
    private void Awake()
    {
        blocks = FindObjectsByType<BlockManager>(FindObjectsSortMode.InstanceID);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DestroyBlocks(int x, int z)
    {
        foreach (var block in blocks)
        {
            if(block!=null && (block.posX <x ||block.posZ <z))
            {
                Destroy(block.gameObject);
            }
        }
    }
}
