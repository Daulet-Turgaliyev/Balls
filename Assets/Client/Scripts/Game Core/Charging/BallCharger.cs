using Mirror;
using UnityEngine;

public class BallCharger : NetworkBehaviour
{
    [SerializeField] private ElectricalCharge electricalCharge;

    private enum ElectricalCharge
    {
        Minus,
        Plus
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.TryGetComponent(out BallDate ballDate))
        {
            Charger(ballDate);
        }
        if (other.transform.TryGetComponent(out PlayerInteraction player))
            player.UpdateBallStatus();
    }

    private void Charger(BallDate ballDate)
    {
        if (electricalCharge == 0)
            ballDate.ChangingCharge(-1);
        else
            ballDate.ChangingCharge(1);
    }
}