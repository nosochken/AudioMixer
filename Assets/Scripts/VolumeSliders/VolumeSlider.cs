using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class VolumeSlider : MonoBehaviour
{
	private const string SliderValue = "SliderValue";
	private const float AmplitudeToDecibelFactor = 20f;
	private const float MinSliderValueForSound = 0.0001f;
	
	[SerializeField] private AudioMixer _audioMixer;
	
	private Slider _slider;
	
	private string _audioMixerParameter;
	
	protected virtual void Awake()
	{
		_slider = GetComponent<Slider>();
		_slider.minValue = MinSliderValueForSound;
	}
	
	private void OnEnable()
	{
		_slider.onValueChanged.AddListener(ChangeVolume);
	}
	
	private void Start()
	{
		_slider.value = PlayerPrefs.GetFloat(SliderValue, _slider.maxValue);
		_audioMixer.SetFloat(_audioMixerParameter, PlayerPrefs.GetFloat(_audioMixerParameter, SoundState.SoundOn));
	}
	
	private void OnDisable()
	{
		_slider.onValueChanged.RemoveListener(ChangeVolume);
	}
	
	protected void SetAudioMixerParameter(string audioMixerParameter)
	{
		_audioMixerParameter = audioMixerParameter;
	}
	
	private void ChangeVolume(float value)
	{
		float volumeIndB = Mathf.Log10(value) * AmplitudeToDecibelFactor;
		
		_audioMixer.SetFloat(_audioMixerParameter, volumeIndB);
		PlayerPrefs.SetFloat(_audioMixerParameter, volumeIndB);
		
		PlayerPrefs.SetFloat(SliderValue, value);
	}
}