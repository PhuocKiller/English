using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public WinPanelManager winPanelManager;
    public LosePanelManager losePanelManager;
    public PlayerController playerController;
    public CheckPanel checkPanel;
    [SerializeField] Image[] heartLives;
    public void PlayAgain()
    {
        StartCoroutine(DelayLoadScene());
    }
    IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
       
    }
    public void UpdateHealth(int lives)
    {
        for (int i = 2; i >= lives; i--)
        {
            heartLives[i].enabled = false;
        }
    }
    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
