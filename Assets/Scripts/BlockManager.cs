using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public bool isChosing;
    public int posX,posZ;
    public Material mat1, mat2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posX=(int)transform.position.x==0?0 : (int)transform.position.x==5?1 : 2;
        posZ = (int)transform.position.z == 0 ? 0 : (int)transform.position.z == 5 ? 1 : 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().material = isChosing ? mat2:mat1;
    }
}
