using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Finish : MonoBehaviour
    {
    [SerializeField] private AudioSource _winning;
    
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.name == "Player")
            {
                _winning.Play();
                Invoke("CompleteLevel", 2f);
                col.GetComponent<PlayerMovement>().EnableMoving(false);
            }
        }

        private void CompleteLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}