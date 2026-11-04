using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public float speed;
    Vector2 targetPos;

    public GameObject points;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        wayPoints = new Transform[points.transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = points.transform.GetChild(i);
        }
    }

    void Start()
    {
       pointCount = wayPoints.Length;
       pointIndex = 1;
       targetPos = wayPoints[pointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].position;

    }
}
