using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletObserver : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _explosionParticles;

    public void OnExplosionPlayFire(Vector3 position)
    {
        var spawnParticles = Instantiate(_explosionParticles[0], position, Quaternion.identity);
        spawnParticles.Play();
        Destroy(spawnParticles.gameObject, 1f);
    }

    public void OnExplosionPlayLightning(Vector3 position)
    {
        var spawnParticles = Instantiate(_explosionParticles[1], position, Quaternion.identity);
        spawnParticles.Play();
        Destroy(spawnParticles.gameObject, 1f);
    }

    private IEnumerator LightningEffectRoutine(Vector3 position)
    {
        var spawnParticles = Instantiate(_explosionParticles[2], position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        spawnParticles.Play();
        Destroy(spawnParticles.gameObject, 5f);
    }

    public void FireEffectRoutine(Vector3 position)
    {
        var spawnParticles = Instantiate(_explosionParticles[3], position, Quaternion.identity);
        spawnParticles.Play();
        Destroy(spawnParticles.gameObject, 5f);
    }

    public void PlayLightningEffectOnTarget(Vector3 position)
    {
        StartCoroutine(LightningEffectRoutine(position));
    }
}
