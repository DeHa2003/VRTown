using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class DroneInteractor : Interactor
    {
        public Drone Drone { get; private set; }

        private Transform posSpawnDrone;

        public void SetData(Drone drone, Transform posSpawn)
        {
            this.Drone = drone;
            this.posSpawnDrone = posSpawn;
        }

        public void ActivateDrone()
        {
            Drone.Activate();
        }

        public void DeactivateDrone() 
        {
            Drone.TeleportToPosition(posSpawnDrone.position);
            Drone.Deactivate();
        }
    }
}
