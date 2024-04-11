using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] private protected ObstacleType obstacleType;

    private protected PlayerController playerController;

    public virtual void Initialize() 
    {
        playerController = Handler.Instance.GetController<PlayerController>();
    }

}

public enum ObstacleType
{
    Wheel, PedestrianCrossing 
}
