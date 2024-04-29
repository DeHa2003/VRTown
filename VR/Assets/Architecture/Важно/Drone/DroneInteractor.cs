using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class DroneInteractor : Interactor
    {
        public Drone Drone { get; private set; }

        public void SetData(Drone drone)
        {
            this.Drone = drone;
        }

        public void ActivateDrone()
        {
            Drone.Activate();
        }

        public void DeactivateDrone() 
        {
            Drone.Deactivate();
        }
    }
}
