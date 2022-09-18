using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [Header("Quit")]
    [SerializeField] private GameObject quitPanel;
    [SerializeField] private GameObject YButton;

    private Vector3 defaultYButtonPosition;

    private void Start()
    {
        defaultYButtonPosition = YButton.transform.position;

        musicSlider.value = AudioManager.Instance.GetMusicVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) return;

        if (Input.anyKeyDown)
        {
            GameManager.Instance.StartGame();
        }

        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
    }

    public void OpenSetting()
    {
        settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void OpenQuit()
    {
        quitPanel.SetActive(true);
    }

    public void CloseQuit()
    {
        quitPanel.SetActive(false);
        YButton.transform.position = defaultYButtonPosition;
    }

    public void RandomButtonPosition()
    {
        Vector3 position = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0);
        YButton.transform.position = position;
    }
}
