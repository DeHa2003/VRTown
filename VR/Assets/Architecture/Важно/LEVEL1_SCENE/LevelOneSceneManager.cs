using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[LevelOneSceneConfig.SCENE_NAME] = new LevelOneSceneConfig();
    }
}
