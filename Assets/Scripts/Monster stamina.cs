using UnityEngine;

public class Monsterstamina : MonoBehaviour
{
    
    [SerializeField] GameObject Monshealth;

    public void SetHP(float hpNormalized)
    {
        Monshealth.transform.localScale = new Vector3(hpNormalized, 1f);
    }
}

