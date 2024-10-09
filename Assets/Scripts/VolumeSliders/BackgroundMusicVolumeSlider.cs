public class BackgroundMusicVolumeSlider : VolumeSlider
{
    protected override void Awake()
    {
        base.Awake();

        SetAudioMixerParameter(AudioMixerParameters.BackgroundSoundVolume);
    }
}