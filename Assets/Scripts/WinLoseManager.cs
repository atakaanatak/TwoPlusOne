using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace

{
    public class WinLoseManager : MonoBehaviour
    {
        public void NewGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}