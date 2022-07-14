using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "GameState", menuName = "Game", order = 0)]
    public class GameState : ScriptableObject
    {
        [SerializeField]
        public int Life = 3;

        public int MaxScore = 10;

        public void LooseLife()
        {
            if (Life == 1)
            {
                Life = 3;
                SceneManager.LoadScene(1);
            }
            else
            {
                Life--;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
    }
}