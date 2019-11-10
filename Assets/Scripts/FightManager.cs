using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour
{
    public Tanks.AbstractTank[] tanks;
    // Start is called before the first frame update
    void Start()
    {
        tanks = GameObject.FindObjectsOfType<Tanks.AbstractTank>();
        foreach (Tanks.AbstractTank t in tanks)
        {
            t.SetFightManager(this);
        }
        AudioEngine.PlaySound(Sounds.StartHorn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterDeath(Tanks.AbstractTank tank)
    {
        tank.gameObject.SetActive(false);
        Debug.Log(tank.player + " died!");
        StartCoroutine(LoadLevel(2f, SceneManager.GetActiveScene()));
    }

    private IEnumerator LoadLevel(float delay, Scene scene)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene.name);
    }
}
