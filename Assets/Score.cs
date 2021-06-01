using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int _score;
    
    private Text _scoreText;

    void Start()
    {
        _scoreText = GetComponent<Text>();
        _scoreText.text = _score.ToString();
    }

    void Update()
    {
        
    }

    public void ScoreHit(int _scorePerHit)
    {
        _score += _scorePerHit;
        _scoreText.text = _score.ToString();
    }
}
