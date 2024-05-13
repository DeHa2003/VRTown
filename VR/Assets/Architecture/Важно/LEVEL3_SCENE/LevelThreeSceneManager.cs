using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[LevelThreeSceneConfig.SCENE_NAME] = new LevelThreeSceneConfig();
    }
}
