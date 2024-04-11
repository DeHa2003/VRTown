using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


[CreateAssetMenu(fileName = "Level description")]
public class LevelDescriptionScriptableObject : ScriptableObject, ILevelDescription
{
    [SerializeField] private string levelNumber;
    [SerializeField] private string levelName;
    [SerializeField] private string levelDescription;
    [SerializeField] private int levelScene;
    [SerializeField] private VideoClip videoClip;

    public string LevelNumber => levelNumber;

    public string LevelName => levelName;

    public VideoClip VideoClip => videoClip;

    public int LevelScene => levelScene;

    public string LevelDescription => levelDescription;
}
