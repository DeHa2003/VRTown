using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lessons.Architecture;

public class StartSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[StartSceneConfig.SCENE_NAME] = new StartSceneConfig();
    }
}
