using UnityEngine;

public class MonsterHPBar : MonoBehaviour
{
    
    [SerializeField] GameObject Monhealth;

    public void SetHP(float hpNormalized)
    {
        Monhealth.transform.localScale = new Vector3(hpNormalized, 1f);
    }
}
