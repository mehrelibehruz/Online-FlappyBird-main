using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] AudioSource mainAudioSource;

    [Header(" -Clips- ")]
    [SerializeField] AudioClip startClip;
    [SerializeField] AudioClip scoreClip;
    [SerializeField] AudioClip submitNameClip;
    [SerializeField] AudioClip gameOverClip;
    [SerializeField] AudioClip backClip;
    [SerializeField] AudioClip restartClip;
    [SerializeField] AudioClip exitClip;

    //[Header(" -Musics- ")]
    // [SerializeField] AudioClip backroundMusic;

    public void Restart_MP3()
    {
        mainAudioSource.PlayOneShot(restartClip);
    }
    public void GameOver_MP3()
    {
        mainAudioSource.PlayOneShot(gameOverClip);
    }
    public void Back_MP3()
    {
        mainAudioSource.PlayOneShot(backClip);
    }
    public void Exit_MP3()
    {
        mainAudioSource.PlayOneShot(exitClip);
    }
}
