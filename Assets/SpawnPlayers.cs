using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{

    private bool startedGame = false;

    NetworkManager gameManager;

    // Player.SetCustomProperties(Hashtable propsToSet)
    // PhotonNetwork.LocalPlayer
    // 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startedGame)
        {
            return;
        }

        if (gameManager.CheckAllPlayerLoadedLevel())
        {
            //gameManager.callMeOnAllPlayersHaveLevelLoaded();
            startedGame = true;
            

            foreach (Player p in PhotonNetwork.PlayerList)
            {
                Debug.Log("creating player with nick " + p.NickName);
                object playerLoadedLevel;

                if (p.CustomProperties.TryGetValue(AsteroidsGame.PLAYER_LOADED_LEVEL, out playerLoadedLevel))
                {
                }

                if (p.IsLocal) {
                    GameObject tank = PhotonNetwork.Instantiate("Level 1 Tank", Vector3.zero, Quaternion.identity, 0);
                    tank.name = p.NickName;
                }
            }
        }
        else
        {
            Debug.Log("Not all players are ready, waiting to spawn players...");
        }


    }
}
