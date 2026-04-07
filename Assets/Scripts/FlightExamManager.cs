using UnityEngine;
using TMPro; // TextMeshPro library

public class FlightExamManager : MonoBehaviour
{
    [Header("HUD Elements")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    // State Tracking
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    private void Start()
    {
        statusText.text = "System Online. All Clear.";
        statusText.color = Color.green;
    }

    public void EnterDangerZone()
    {
        // Update state and UI when the aircraft enters the zone
        statusText.text = "Entered a Dangerous Zone!";
        statusText.color = Color.red;
        Debug.Log("Mission State: Danger Phase Started");
    }

    public void ExitDangerZone()
    {
        // Clear state and update UI when the aircraft exits the zone
        threatCleared = true;
        statusText.text = "Threat Cleared. Proceed to Landing.";
        statusText.color = Color.yellow;
        Debug.Log("Mission State: Danger Phase Cleared");
    }

    public void PlayerHitByMissile()
    {
        statusText.text = "AIRCRAFT DESTROYED! MISSION FAILED.";
        statusText.color = Color.red;
    }
}