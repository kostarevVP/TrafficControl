using Lofelt.NiceVibrations;
using WKosArch.Common.DIContainer;
using MoreMountains.Tools;
using WKosArch.UIService.Views.Windows;

namespace WKosArch.Services.SoundService
{
    public class SoundSettingViewModel : WindowViewModel
    {
        private const float MinimalVolume = 0.0001f;

        private ISoundService _soundService;

        private float _previousMusicVolumeValue;
        private float _previousSFXVolumeValue;
        private float _previousUIVolumeValue;

        private SoundManager _soundManager => _soundService.SoundManager;
        private MMSoundManager _mmSoundManager => _soundManager.MMSoundManager;
        private HapticReceiver _hapticReceiver => _soundManager.HapticReceiver;

        public float MusicVolumeValue { get; private set; }
        public float SFXVolumeValue { get; private set; }
        public float UIVolumeValue { get; private set; }
        public bool MusicToggleState { get; private set; }
        public bool SFXToggle { get; private set; }
        public bool UIToggle { get; private set; }
        public bool HapticToogle { get; private set; }


        protected override void AwakeInternal()
        {
            base.AwakeInternal();

            _soundService = new DIVar<ISoundService>().Value;

            GetValueFromSettingSO();
        }

        internal void SetMusicValue(float value)
        {
            if (value <= MinimalVolume)
            {
                _mmSoundManager.SetVolumeMusic(MinimalVolume);
                MusicVolumeValue = MinimalVolume;
                SwitchMusic(false);
            }
            else
            {
                if (!MusicToggleState)
                {
                    _previousMusicVolumeValue = MusicVolumeValue;
                    MusicVolumeValue = value;
                    _mmSoundManager.SetVolumeMusic(value);
                    SwitchMusic(true);
                }
                else
                {
                    _previousMusicVolumeValue = MusicVolumeValue;
                    MusicVolumeValue = value;
                    _mmSoundManager.SetVolumeMusic(value);
                }
            }
        }

        internal void SetSFXValue(float value)
        {
            if (value <= MinimalVolume)
            {
                _mmSoundManager.SetVolumeSfx(MinimalVolume);
                SFXVolumeValue = MinimalVolume;
                SwithcSFX(false);
            }
            else
            {
                if (!SFXToggle && SFXVolumeValue < value)
                {
                    _previousSFXVolumeValue = SFXVolumeValue;
                    _mmSoundManager.SetVolumeSfx(value);
                    SFXVolumeValue = value;
                    SwithcSFX(true);
                }
                else
                {
                    _previousSFXVolumeValue = SFXVolumeValue;
                    _mmSoundManager.SetVolumeSfx(value);
                    SFXVolumeValue = value;
                }
            }
        }

        internal void SetUiValue(float value)
        {
            if (value <= MinimalVolume)
            {
                _mmSoundManager.SetVolumeUI(MinimalVolume);
                UIVolumeValue = MinimalVolume;
                SwithcUI(false);
            }
            else
            {
                if (!UIToggle && UIVolumeValue < value)
                {
                    _previousUIVolumeValue = UIVolumeValue;
                    _mmSoundManager.SetVolumeUI(value);
                    UIVolumeValue = value;
                    SwithcUI(true);
                }
                else
                {
                    _previousUIVolumeValue = UIVolumeValue;
                    _mmSoundManager.SetVolumeUI(value);
                    UIVolumeValue = value;
                }
            }
        }


        internal void SwitchMusic(bool isEnabled)
        {
            MusicToggleState = isEnabled;

            if (isEnabled)
            {
                _mmSoundManager.UnmuteMusic();

                if (MusicVolumeValue <= _previousMusicVolumeValue)
                    MusicVolumeValue = _previousMusicVolumeValue;
            }
            else
            {
                _mmSoundManager.MuteMusic();
                MusicVolumeValue = MinimalVolume;
            }

            Refresh();
        }

        internal void SwithcSFX(bool isEnabled)
        {
            SFXToggle = isEnabled;

            if (isEnabled)
            {
                _mmSoundManager.UnmuteSfx();

                if (SFXVolumeValue <= _previousSFXVolumeValue)
                    SFXVolumeValue = _previousSFXVolumeValue;
            }
            else
            {
                _mmSoundManager.MuteSfx();
                SFXVolumeValue = MinimalVolume;
            }

            Refresh();
        }

        internal void SwithcUI(bool isEnabled)
        {
            UIToggle = isEnabled;

            if (isEnabled)
            {
                _mmSoundManager.UnmuteUI();

                if (UIVolumeValue <= _previousUIVolumeValue)
                    UIVolumeValue = _previousUIVolumeValue;
            }
            else
            {
                _mmSoundManager.MuteUI();
                UIVolumeValue = MinimalVolume;
            }

            Refresh();
        }

        internal void SwitchHaptic(bool isEnabled)
        {
            _hapticReceiver.hapticsEnabled = isEnabled;
            HapticToogle = isEnabled;
        }

        private void GetValueFromSettingSO()
        {
            var settigs = _mmSoundManager.settingsSo.Settings;

            MusicVolumeValue = _previousMusicVolumeValue = settigs.MusicVolume;
            SFXVolumeValue = _previousSFXVolumeValue = settigs.SfxVolume;
            UIVolumeValue = _previousUIVolumeValue = settigs.UIVolume;

            MusicToggleState = settigs.MusicOn;
            SFXToggle = settigs.SfxOn;
            UIToggle = settigs.UIOn;

            HapticToogle = _hapticReceiver.hapticsEnabled;
        }

        internal void WindowBack()
        {
            UI.Back();
        }
    }
}