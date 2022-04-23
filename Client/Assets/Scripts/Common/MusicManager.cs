using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource source;
    private Coroutine coroutine;
    private int currentIndex;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
    private void Start()
    {
        StartRandomClip();
    }
    public float GetVolume()
    {
        return source.volume;
    }
    public void SetVolume(float value)
    {
        source.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void Next()
    {
        StartNextClip();
    }
    private IEnumerator WaitForClip(float length)
    {
        yield return new WaitForSeconds(length);
        StartRandomClip();
    }
    private void StartNextClip()
    {
        currentIndex = ++currentIndex >= clips.Length ? 0 : currentIndex;
        source.clip = clips[currentIndex];
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(WaitForClip(source.clip.length));
        source.Play();
    }
    private void StartRandomClip()
    {
        currentIndex = Random.Range(0, clips.Length);
        source.clip = clips[currentIndex];
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(WaitForClip(source.clip.length));
        source.Play();
    }
}
