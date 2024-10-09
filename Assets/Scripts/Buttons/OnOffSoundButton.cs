using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OnOffSoundButton : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(TurnOnOffSound);
    }

    private void Start()
    {
        _audioMixer.SetFloat(AudioMixerParameters.MasterVolume,
            PlayerPrefs.GetFloat(AudioMixerParameters.MasterVolume, SoundState.SoundOn));
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TurnOnOffSound);
    }

    private void TurnOnOffSound()
    {
        _audioMixer.GetFloat(AudioMixerParameters.MasterVolume, out float value);

        float newValue = value == SoundState.SoundOn ? SoundState.SoundOff : SoundState.SoundOn;

        _audioMixer.SetFloat(AudioMixerParameters.MasterVolume, newValue);
        PlayerPrefs.SetFloat(AudioMixerParameters.MasterVolume, newValue);
    }
}