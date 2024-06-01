using UnityEngine;

public class Trigger_PedestrianCross : Trigger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GamePlayer>() || other.GetComponent<Camera>())
        {
            if (isActive)
            {
                Debug.Log(this.name);
                if (playerController != null)
                    playerController.SetPlayerFailedState_PedestrianCross();
            }
        }
    }
}
