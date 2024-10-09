public class MasterVolumeSlider : VolumeSlider
{
	protected override void Awake()
	{
		base.Awake();
		
		SetAudioMixerParameter(AudioMixerParameters.MasterVolume);
	}
}