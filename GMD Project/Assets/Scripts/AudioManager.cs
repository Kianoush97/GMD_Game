using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private int soundOn = 1;
    [SerializeField] Button soundBtn;
    [SerializeField] Sprite SoundOnImage;
    [SerializeField] Sprite SoundOffImage;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        soundOn = PlayerPrefs.GetInt("soundOn", soundOn);

        if (soundOn == 1)
        {
            soundBtn.image.sprite = SoundOnImage;
            AudioListener.volume = 1;
        }
        else
        {
            soundBtn.image.sprite = SoundOffImage;
            AudioListener.volume =0;
        }
    }

    private void Update()
    {
        soundOn = PlayerPrefs.GetInt("soundOn", soundOn);
    }

    public void Audio()
    {
        if (soundOn == 1)
        {
            soundBtn.image.sprite = SoundOffImage;
            PlayerPrefs.SetInt("soundOn", 0);
            AudioListener.volume = 0;
        }
        else
        {
            soundBtn.image.sprite = SoundOnImage;
            PlayerPrefs.SetInt("soundOn", 1);
            AudioListener.volume = 1;
        }
    }
}
