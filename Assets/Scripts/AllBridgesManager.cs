using UnityEngine;

public class AllBridgesManager : MonoBehaviour
{
    public Bridge[] bridges;
    private void Awake()
    {
        bridges = FindObjectsByType<Bridge>(FindObjectsSortMode.InstanceID);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DestroyBridges(int x, int z)
    {
        foreach (var bridge in bridges)
        {
            if (bridge != null && (bridge.posX < x || bridge.posZ < z))
            {
                Destroy(bridge.gameObject);
            }
        }
    }
}
