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
            foreach (var player in _players)
            {
                player.Inject(this);
            }
        }

        public abstract void OnPlayerHitByBall(PlayerViewElement player);
    }
}