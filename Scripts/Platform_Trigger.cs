using UnityEngine;

public class Platform_Trigger : MonoBehaviour
{
    bool spawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player") && !spawned)
        {
            GetComponentInParent<Platform_Script>().SpawnNextPlatform();
            spawned = true;
        }
    }
}
