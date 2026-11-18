using UnityEngine;

public class MovingArrow : MonoBehaviour
{

    private Transform target;
    private float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(Transform targetTransform, float speed)
    {
        target = targetTransform;
        moveSpeed = speed;
    }   

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            {
                return;
            } 
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Destroy(gameObject); // Destroy the arrow when it reaches the target
        }

    }
}
