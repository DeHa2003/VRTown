using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public interface ILevelDescription
{
    string LevelNumber { get; }
    string LevelName { get; }
    string LevelDescription { get; }
    VideoClip VideoClip { get; }
    int LevelScene { get; }
}
