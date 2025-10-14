using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanelManager : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlayerPlayerSound(audioManager.lose);
    }
}
