using UnityEngine;

public class LocksManager : MonoBehaviour
{

    public Unlock[] locks; // Array to hold references to all Unlock scripts in the scene
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public bool CheckLocks()
    {
        if (locks == null || locks.Length == 0)
        {
            Debug.LogWarning("No locks assigned to the LocksManager.");
            return false;
        }

        foreach (Unlock currentLock in locks)
        {
            if (currentLock != null && !currentLock.isUnlocked)
            {
                return false;
            }
        }

        Debug.Log("All locks are unlocked!");
        return true;
    }
}
