using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] VoidEventChannel deathEvent;
    [SerializeField] AudioClip[] voiceClip;
    [SerializeField] Button retryButton;
    [SerializeField] Button quitButton;

    private void OnEnable()
    {
        deathEvent.AddListener(ShowUI);
        retryButton.onClick.AddListener(SceneLoader.ReLoadScene);
        quitButton.onClick.AddListener(SceneLoader.QuitGame);
    }

    private void OnDisable()
    {
        deathEvent.removeListener(ShowUI);
        retryButton.onClick.RemoveListener(SceneLoader.ReLoadScene);
        quitButton.onClick.RemoveListener(SceneLoader.QuitGame);
    }

    private void ShowUI()
    {
        GetComponent<Canvas>().enabled = true;
        GetComponent<Animator>().enabled = true;
        AudioClip clip = voiceClip[Random.Range(0,voiceClip.Length)];
        SFXPlayer.audioPlayer.PlayOneShot(clip);
    }
}
