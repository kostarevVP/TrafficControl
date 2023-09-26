﻿using System;
using UnityEngine;

namespace WKosArch.UIService.Views.Windows
{
    [Serializable]
    public class SceneConfigUI
    {
        [SerializeField] private string _sceneName;
        [SerializeField] private string _sceneViewModelsFileName;

        public string SceneName => _sceneName;
        public string SceneViewModelsFileName => _sceneViewModelsFileName;
    }
}