using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _deathExplosion;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _scoreToAdd = 5;
    [SerializeField] private int hits = 2;

    private Score _scoreBoard;
   
    void Start()
    {
        _scoreBoard = FindObjectOfType<Score>();
    }

    void OnParticleCollision(GameObject other)
    {
        _scoreBoard.ScoreHit(_scoreToAdd);
        hits -= 1;
        if(hits <=0)
            DeathEnemy();
    }

    private void DeathEnemy()
    {
        GameObject explposion = Instantiate(_deathExplosion, transform.position, Quaternion.identity);
        explposion.transform.parent = _parent;
        Destroy(gameObject);
    }

}
