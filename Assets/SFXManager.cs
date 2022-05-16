using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip[] sfxClips;
    public AudioSource sfxSource;

    public AudioClip[] bombClips;
    public AudioSource bombSource;


    public void PlaySFX()
    {
        sfxSource.clip = GetSFXClip();
        sfxSource.Play();
    }

    public void PlayBombSFX()
    {
        bombSource.clip = GetBombSFXClip();
        bombSource.Play();
    }

    private AudioClip GetSFXClip()
    {
        int randomIndex = Random.Range(0, sfxClips.Length - 1);
        return sfxClips[randomIndex];
    }

    private AudioClip GetBombSFXClip()
    {
        int randomIndex = Random.Range(0, bombClips.Length - 1);
        return bombClips[randomIndex];
    }

}
