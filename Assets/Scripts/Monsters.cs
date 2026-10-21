using UnityEngine;

public class Monsters : MonoBehaviour
{

    [SerializeField] GameObject Mhealth;

    public void SetHP(float hpmonster)
    {
        health.transform.localScale = new Vector3(hpmonster, 1f);
    }

}
