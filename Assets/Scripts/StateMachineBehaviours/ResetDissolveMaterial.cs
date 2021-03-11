using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDissolveMaterial : StateMachineBehaviour
{
    [SerializeField] private Material _dissolveMaterial;
    
    private static readonly int Fade = Shader.PropertyToID("_Fade");

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _dissolveMaterial.SetFloat(Fade, 1f);
    }
}
