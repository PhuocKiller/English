using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public WinPanelManager winPanelManager;
    public LosePanelManager losePanelManager;
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
