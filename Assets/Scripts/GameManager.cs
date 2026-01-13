using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public GameObject WinScreen;
        public GameObject LoseScreen;

        private void Start()
        {
            Alice.OnGameOver += OpenLoseScreen;
            RoomManager.OnGameWon += OpenWinScreen;
        }

        private void OnDestroy()
        {
            Alice.OnGameOver -= OpenLoseScreen;
            RoomManager.OnGameWon -= OpenWinScreen;
        }

        private void OpenWinScreen()
        {
            WinScreen.SetActive(true);
        }

        private void OpenLoseScreen()
        {
            LoseScreen.SetActive(true);
        }
    }
}