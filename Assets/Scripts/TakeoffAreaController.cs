using UnityEngine;

public class TakeoffAreaController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            examManager.ConfirmTakeoff();
        }
    }
}