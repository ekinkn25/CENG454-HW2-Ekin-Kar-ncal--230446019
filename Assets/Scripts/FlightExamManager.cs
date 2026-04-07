using UnityEngine;
using TMPro; // TextMeshPro library

public class FlightExamManager : MonoBehaviour
{
    [Header("HUD Elements")]
    [SerializeField] private TMP_Text statusText; // Text to display current flight status
    [SerializeField] private TMP_Text missionText; // Text to display main mission objectives

    [SerializeField] private AudioSource successAudioSource; // Played upon successful mission completion

    // State Tracking
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    private bool isMissionFailed = false;

    private void Start()
    {
        statusText.text = "System Online. All Clear.";
        statusText.color = Color.green;
    }

    public void ConfirmTakeoff()
    {
        // Prevent state changes if the mission is already resolved (won or lost)
        if (isMissionFailed || missionComplete) return;

        // Ensure takeoff is only confirmed once
        if (!hasTakenOff)
        {
            hasTakenOff = true;
            statusText.text = "Airborne. Proceed to Danger Zone.";
            statusText.color = Color.cyan;
            Debug.Log("Mission State: Takeoff Confirmed");
        }
    }

    public void EnterDangerZone()
    {
        if (isMissionFailed || missionComplete) return;

        // Update state and UI when the aircraft enters the zone
        statusText.text = "Entered a Dangerous Zone!";
        statusText.color = Color.red;
        Debug.Log("Mission State: Danger Phase Started");
    }

    public void ExitDangerZone()
    {
        if (isMissionFailed || missionComplete) return;

        // Clear state, mark the threat as clear and update game when the aircraft exits the zone
        threatCleared = true;
        statusText.text = "Threat Cleared. Proceed to Landing.";
        statusText.color = Color.yellow;
        Debug.Log("Mission State: Danger Phase Cleared");
    }

    public void PlayerHitByMissile()
    {
        if (missionComplete || isMissionFailed) return;

        // Trigger mission by failure 
        isMissionFailed = true;
        statusText.text = "AIRCRAFT DESTROYED! MISSION FAILED.";
        statusText.color = Color.red;
    }

    public void AttemptLanding()
        {
            // if aircraft is already destroyed
            if (isMissionFailed) 
            {
                Debug.Log("Mission State: Landing ignored because plane is already destroyed.");
                return; 
            }

            // to prevent multiple landing
            if (missionComplete) return;

            // Validating the mission constraints
            if (hasTakenOff == false || threatCleared == false)
            {
                statusText.text = "LANDING REJECTED! Clear the Danger Zone first.";
                statusText.color = Color.red;
                Debug.Log("Mission State: Invalid Landing Attempted.");
                return;
            }
            // successful landing
            missionComplete = true;
            statusText.text = "MISSION COMPLETE! Perfect Landing.";
            statusText.color = Color.green;
            Debug.Log("Mission State: Valid Landing. Game Won.");
            
            if (successAudioSource != null) successAudioSource.Play();
        }
    }