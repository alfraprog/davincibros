using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCollection : MonoBehaviour
{
    public GameObject cannonLaunchEffectPrefab;

    public GameObject explosionPrefab;

    public GameObject GetLaunchSmokeEffect() 
    { 
        return Instantiate(cannonLaunchEffectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public GameObject GetExplosionEffect()
    {
        return Instantiate(cannonLaunchEffectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
