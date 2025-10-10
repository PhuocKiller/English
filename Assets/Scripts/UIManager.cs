using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public WinPanelManager winPanelManager;
    public LosePanelManager losePanelManager;
    public PlayerController playerController;
    public CheckPanel checkPanel;
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
       
    }
    
}
