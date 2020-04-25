
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip CoinSound;
    public AudioClip PlayerJumpSound;
    public AudioClip ButtonClick;
    public AudioClip AttackSound;

    private AudioSource audioSource;

    public static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();

                if (_instance == null)
                {
                    GameObject container = new GameObject("AudioManager");
                    _instance = container.AddComponent<AudioManager>();
                }
                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayCoinClip()
    {
        audioSource.PlayOneShot(CoinSound);
    }


    public void PlayPlayerJumpSound()
    {
        audioSource.PlayOneShot(PlayerJumpSound);
    }

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(ButtonClick);
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(AttackSound);
    }


}
