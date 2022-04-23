using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button nextBtn;
    private MusicManager music;
    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("Music").GetComponent<MusicManager>();
        nextBtn.onClick.AddListener(music.Next);
        slider.value = music.GetVolume();
        slider.onValueChanged.AddListener(ChangeVolume);
    }
    private void ChangeVolume(float value)
    {
        music.SetVolume(value);
    }
}
