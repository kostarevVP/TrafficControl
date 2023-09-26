using Assets.Game.Services.ProgressService.api;
using System.Collections.Generic;

namespace WKosArch.Services.SoundService
{
    public class SoundService : ISoundService
    {
        public SoundManager SoundManager { get; private set; }
        public List<ILoadProgress> ProgressReaders { get; } = new List<ILoadProgress>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();
        public bool IsReady => _isReady;


        private bool _isReady;

        public SoundService()
        {
            SoundManager = SoundManager.CreateInstance();
            
            RegisterProgressWatchers(SoundManager);

            _isReady = true;
        }

        private void RegisterProgressWatchers(SoundManager gameObject)
        {
            foreach (var progressReader in gameObject.GetComponentsInChildren<ISavedProgress>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgress progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
            {
                ProgressWriters.Add(progressWriter);
            }

            ProgressReaders.Add(progressReader);
        }
    }
}