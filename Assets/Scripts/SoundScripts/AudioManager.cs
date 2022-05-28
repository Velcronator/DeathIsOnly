using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFXTYPE
{
    clicks = 0,
    die,
    enviro,
    footsteps,
    increment,
    lasers,
}
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    private AudioSource as_sfx;

    //[SerializeField] private AudioClip[] musics = default;
    //[SerializeField] private AnimationCurve curve_musicFade = default;

    [SerializeField] private SFXGroup[] sfxGroups = default;

    [System.Serializable]
    private class SFXGroup
    {
        [SerializeField] private string name = default;
        public AudioClip[] sounds;
        public float[] volumes;
    }

    void Awake()
    {
        instance = this;
        as_sfx = transform.Find("AS_SFX").GetComponent<AudioSource>();
    }

    public void RequestSFX(SFXTYPE sfx)
    {
        as_sfx.PlayOneShot(
            sfxGroups[(int)sfx].sounds[Random.Range(0, sfxGroups[(int)sfx].sounds.Length)],
            Random.Range(sfxGroups[(int)sfx].volumes[0], sfxGroups[(int)sfx].volumes[1])
        );
    }
}
