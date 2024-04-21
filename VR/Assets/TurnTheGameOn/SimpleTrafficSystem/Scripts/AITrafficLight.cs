namespace TurnTheGameOn.SimpleTrafficSystem
{
    using UnityEngine;
    using UnityEngine.Events;

    public class AITrafficLight : MonoBehaviour
    {
        public UnityEvent OnEnableGreen;
        public UnityEvent OnEnableRed;
        //----------------------------//
        public MeshRenderer redMesh;
        public MeshRenderer yellowMesh;
        public MeshRenderer greenMesh;
        public AITrafficWaypointRoute waypointRoute;

        public void EnableRedLight()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(true);
            redMesh.enabled = true;
            yellowMesh.enabled = false;
            greenMesh.enabled = false;

            OnEnableRed?.Invoke();
        }

        public void EnableYellowLight()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(true);
            redMesh.enabled = false;
            yellowMesh.enabled = true;
            greenMesh.enabled = false;
        }

        public void EnableGreenLight()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(false);
            redMesh.enabled = false;
            yellowMesh.enabled = false;
            greenMesh.enabled = true;

            OnEnableGreen?.Invoke();
        }

        public void DisableAllLights()
        {
            if (waypointRoute) waypointRoute.StopForTrafficlight(true);
            redMesh.enabled = false;
            yellowMesh.enabled = false;
            greenMesh.enabled = false;
        }

    }
}