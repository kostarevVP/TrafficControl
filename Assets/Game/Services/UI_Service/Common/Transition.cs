﻿using System.Threading.Tasks;
using UnityEngine;

namespace WKosArch.UI_Service.Common
{
    public abstract class Transition : MonoBehaviour
    {
        public bool IsPlaying { get; private set; }

        public async Task Play()
        {
            IsPlaying = true;

            await PlayInternal();

            IsPlaying = false;
        }

        protected abstract Task PlayInternal();
    }
}