using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[LevelTwoSceneConfig.SCENE_NAME] = new LevelTwoSceneConfig();
    }
}
