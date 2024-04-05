using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[MainSceneConfig.SCENE_NAME] = new MainSceneConfig();
    }
}
