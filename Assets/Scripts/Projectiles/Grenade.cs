using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float fuseTime;
    public float explosionForce;
    public float explosionRadius;

    public ParticleSystem explosionEffect;

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
        GameObject explosion = Instantiate(explosionEffect.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
        explosion.transform.position = transform.position;
        explosion.GetComponent<ParticleSystem>().Play();

        foreach(GameObject tank in GameObject.FindGameObjectsWithTag("Player"))
        {
            tank.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, .2f, ForceMode.Impulse);
        }
        AudioEngine.PlaySound(Sounds.MassiveExplosion);
        Destroy(explosion, 2.0f);
        Destroy(gameObject);
    }
}
