using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _deathExplosion;
    [SerializeField] private Transform _parent;

    void OnParticleCollision(GameObject other)
    {
        GameObject explposion = Instantiate(_deathExplosion, transform.position, Quaternion.identity);
        explposion.transform.parent = _parent;
        Destroy(gameObject);
    }
}
