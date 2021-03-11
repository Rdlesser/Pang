using System;
using System.Collections;
using System.Collections.Generic;
using Abstracts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : GameManagerElement
    {
        [SerializeField] private GameObject _deathPanel;

        private void Start()
        {
            _deathPanel.SetActive(false);
            Time.timeScale = 1;
        }

        private void Update()
        {
            if (_deathPanel.activeInHierarchy)
            {
                if (Input.GetKeyDown("r"))
                {
                    RestartLevel();
                }
                else if (Input.GetKeyDown("q"))
                {
                    QuitToMainMenu();
                }
            }
        }

        public override void OnPlayerHitByBall(PlayerViewElement player)
        {
            StartCoroutine(PlayerDeathRoutine(player));
        }

        private IEnumerator PlayerDeathRoutine(PlayerViewElement player)
        {
            player.Die();
            yield return new WaitForSeconds(2.7f);
            Time.timeScale = 0;
            _deathPanel.SetActive(true);
            
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, 
                                   LoadSceneMode.Single);
        }

        public void QuitToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}