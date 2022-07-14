using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameState _state;
    [SerializeField] private Text _maxScore;
    
    // Start is called before the first frame update
    void Start()
    {
        _maxScore.text = "Max Score : " + _state.MaxScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
