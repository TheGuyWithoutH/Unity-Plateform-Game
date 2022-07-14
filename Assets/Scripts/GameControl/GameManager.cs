using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MovingObject[] movingObjects;

    public void OnPause()
    {
        foreach (var obj in movingObjects)
        {
            obj.Pause();
        }
    }

    public void OnResume()
    {
        foreach (var obj in movingObjects)
        {
            obj.Resume();
        }
    }

    public void OnQuit()
    {
        SceneManager.LoadScene(0);
    }

}
