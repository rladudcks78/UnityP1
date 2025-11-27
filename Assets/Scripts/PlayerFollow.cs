using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float stoppingDistance = 3f;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                Time.deltaTime * speed);
        }
    }
}
