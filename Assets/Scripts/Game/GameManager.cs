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
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private BallControllerElement _ballController;
        [SerializeField] private PlayerControllerElement _playerController;

        private void Start()
        {
            _deathPanel.SetActive(false);
            _winPanel.SetActive(false);
            Time.timeScale = 1;
            _ballController.Inject(this);
        }

        private void Update()
        {
            // Shortcuts for keyboard usage
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

        public override void OnPoppedAllBalls()
        {
            _playerController.PreventPlayerMovement();
            _winPanel.SetActive(true);
        }

        public override void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private IEnumerator PlayerDeathRoutine(PlayerViewElement player)
        {
            player.PreventMovement();
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