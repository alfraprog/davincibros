using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public bool randomFights;
    // Start is called before the first frame update
    void Start()
    {
        if (randomFights)
        {
            GameManager.Instance.StartRandomFightGame();
        } else
        {
            GameManager.Instance.StartGame();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
