using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 40f; 
    [SerializeField] private float turnSpeed = 2f; 

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        // TODO (Task 3-E): cache the aircraft transform
        target = newTarget;
    }

    void Update()
    {
        // TODO (Task 3-F): rotate toward the target and move forward
        if (target == null) return;

        // Hedefe doğru yumuşak dönüş (Slerp) ve ileri doğru uçuş
        // A gentle turn toward the target (Slerp) and flight toward forward 
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}