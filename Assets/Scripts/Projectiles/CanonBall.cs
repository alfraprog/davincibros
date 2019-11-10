using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public float impactForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 normalizedVelocity = GetComponent<Rigidbody>().velocity.normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(normalizedVelocity * impactForce, ForceMode.Impulse);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Death"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Vector3 normalizedVelocity = GetComponent<Rigidbody>().velocity.normalized;
            collider.GetComponent<Rigidbody>().AddForce(normalizedVelocity * impactForce, ForceMode.Impulse);
            Destroy(gameObject);
        } else if (collider.CompareTag("Projectile") || collider.CompareTag("Death"))
        {
            Destroy(gameObject);
        }

    }

    private IEnumerator DestroySelf(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
