using UnityEngine;
using System.Collections; // required for Coroutine

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        // is colliding object's tag Player?
        if (other.CompareTag("Player"))
        {
            // update HUD
            examManager.EnterDangerZone();
            
            // Start missile count down
            // it is a infrastucture for task 3
            activeCountdown = StartCoroutine(MissileCountdownRoutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // clean HUD
            examManager.ExitDangerZone();

            // if plane leaves early stop the count down 
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
                Debug.Log("Player escaped early. Countdown cancelled.");
            }
            
            // TODO: Destroy the active missile (Task 3)
        }
    }

    // 5 second missile count down motor
    private IEnumerator MissileCountdownRoutine()
    {
        Debug.Log("Missile countdown started: 5 seconds...");
        yield return new WaitForSeconds(missileDelay);
        
        Debug.Log("LAUNCH MISSILE!");
        // TODO: launch missile (Task 3)
    }
}