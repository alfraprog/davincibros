using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float fuseTime;
    public float explosionForce;
    public float explosionRadius;

    private void Start()
    {
        StartCoroutine(LightFuse(fuseTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        AudioEngine.PlaySound(Sounds.GrenadeHittingSomething);
    }

    private IEnumerator LightFuse(float fuseTime)
    {

        if (fuseTime > 1f)
        {
            fuseTime--;
            yield return new WaitForSeconds(fuseTime);
        }
        AudioEngine.PlaySound(Sounds.Swish);
        yield return new WaitForSeconds(fuseTime);
        Explode();
    }

    private void Explode()
    {
        foreach(GameObject tank in GameObject.FindGameObjectsWithTag("Player"))
        {
            tank.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, .2f, ForceMode.Impulse);
        }
        AudioEngine.PlaySound(Sounds.MassiveExplosion);
        Destroy(gameObject);
    }
}
