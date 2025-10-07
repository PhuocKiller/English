using UnityEngine;

public class Bridge : MonoBehaviour
{
    public int posX, posZ;
    void Start()
    {
        posX = (int)transform.position.x <4 ? 0 : (int)transform.position.x <9 ? 1 : 2;
        posZ = (int)transform.position.z < 4 ? 0 : (int)transform.position.z < 9 ? 1 : 2;
    }
}
