﻿using WKosArch.Domain.Features;
using UnityEngine;

public interface IGameFactoryFeature : IFeature
{
    GameObject FreeLookCamera { get; }

    void CreateFreeLookCamera();
}