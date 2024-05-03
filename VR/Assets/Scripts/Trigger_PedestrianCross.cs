using UnityEngine;

public class Trigger_PedestrianCross : Trigger
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<GamePlayer>())
        {
            playerController.SetPlayerFailedState_PedestrianCross();
        }
    }
}
