using System.Collections;
using System.Collections.Generic;
using Abstracts;
using UnityEngine;

namespace Game
{
    public class GameManager : GameManagerElement
    {

        public override void OnPlayerHitByBall(PlayerViewElement player)
        {
            Debug.Log("Death!");
            StartCoroutine(PlayerDeathRoutine(player));
        }

        private IEnumerator PlayerDeathRoutine(PlayerViewElement player)
        {
            player.Die();
            yield return new WaitForSeconds(2.5f);
            Time.timeScale = 0;
            
        }
    }
}