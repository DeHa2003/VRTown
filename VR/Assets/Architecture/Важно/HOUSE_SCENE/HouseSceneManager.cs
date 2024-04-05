using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSceneManager : SceneManagerBase
{
    public override void InitSceneMap()
    {
        this.sceneConfigsMap[HouseSceneConfig.SCENE_NAME] = new HouseSceneConfig();
    }
}
