using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameManager;

public class TankInitializer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Tanks.TankController[] tanks = GameObject.FindObjectsOfType<Tanks.TankController>();
        foreach (Tanks.TankController t in tanks)
        {
            t.InitComponents();
        }
        AudioEngine.PlaySound(Sounds.StartHorn);
    }
}
