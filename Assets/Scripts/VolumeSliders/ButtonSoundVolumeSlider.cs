public class ButtonSoundVolumeSlider : VolumeSlider
{
    protected override void Awake()
    {
        base.Awake();

        SetAudioMixerParameter(AudioMixerParameters.ButtonsVolume);
    }
}