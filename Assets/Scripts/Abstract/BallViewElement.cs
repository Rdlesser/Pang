using Interfaces;
using UnityEngine;

namespace Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BallViewElement : MonoBehaviour, IInjectifiable<BallControllerElement>
    {

        public void Inject(BallControllerElement injection)
        {
            throw new System.NotImplementedException();
        }
    }
}