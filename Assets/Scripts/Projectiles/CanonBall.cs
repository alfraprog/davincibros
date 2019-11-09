using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DestroySelf(.2f));
        } else if (collision.gameObject.CompareTag("Death"))
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
