using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    public GameObject prefabCannon;

    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private float sinceLastSpawn = 0f;

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null) {
            return;
        }

        sinceLastSpawn += Time.deltaTime;
        if (sinceLastSpawn > 1)
        {
            sinceLastSpawn = 0;
            photonView.RPC("FireCannon", RpcTarget.AllViaServer, transform.parent.position + Vector3.one, transform.parent.rotation);
        }
    }



    [PunRPC]
    public void FireCannon(Vector3 position, Quaternion rotation, PhotonMessageInfo info)
    {
        float lag = (float)(PhotonNetwork.Time - info.SentServerTime);
        GameObject bullet;

        Debug.Log(rotation);

        bullet = Instantiate(prefabCannon, position, rotation) as GameObject;
        bullet.GetComponent<CannonController>().InitializeCannon(photonView.Owner, (rotation * Vector3.forward), Mathf.Abs(lag));
    }
}
