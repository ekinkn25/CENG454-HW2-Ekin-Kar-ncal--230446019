using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource hitAudioSource;

    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-G): cache GetComponent() into 'rb'
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // DEDEKTİF KODU: Uçağa herhangi bir şey değdiği an konsola yazdıracak.
        Debug.Log("UÇAĞA BİR ŞEY DEĞDİ! Değen Obje: " + other.gameObject.name + " | Tag: " + other.tag);
        // TODO (Task 3-H): if the missile hits the aircraft, apply the chosen penalty
        if (other.CompareTag("Missile"))
        {
            if (hitAudioSource != null) hitAudioSource.Play();
            examManager.PlayerHitByMissile();
            
            // Blow up the missile
            Destroy(other.gameObject);
        }
    }
}