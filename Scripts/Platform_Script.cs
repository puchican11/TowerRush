using UnityEngine;

public class Platform_Script : MonoBehaviour
{
    public Transform nextSpawnPoint;

    public void SpawnNextPlatform() 
    {
        GameManager.instance.NewPlatform();
    }
}
