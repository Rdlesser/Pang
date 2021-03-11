using System;
using System.Collections.Generic;
using UnityEngine;

namespace Abstracts
{
    public abstract class GameManagerElement : MonoBehaviour
    {
        [SerializeField] private List<PlayerViewElement> _players;

        private void Awake()
        {
            // Inject this game manager to all the players
            foreach (var player in _players)
            {
                player.Inject(this);
            }
        }

        /// <summary>
        /// Invoked when a player is hit by a ball
        /// </summary>
        /// <param name="player"> The player hit by the ball </param>
        public abstract void OnPlayerHitByBall(PlayerViewElement player);
    }
}