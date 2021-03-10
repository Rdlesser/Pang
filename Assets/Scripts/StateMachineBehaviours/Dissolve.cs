using UnityEngine;

public class Dissolve : StateMachineBehaviour
{

    [SerializeField] private Material _material;
    [SerializeField][Range(1f, 10f)] private float _timeToFade = 2.2f;
    
    private static readonly int Fade = Shader.PropertyToID("_Fade");
    private static readonly int IsDissolving = Animator.StringToHash("IsDissolving");

    private bool _isDissolving = true;
    private float _fade = 1f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _material.SetFloat(Fade, 1f);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (_isDissolving)
        {
            _fade -= Time.deltaTime / _timeToFade;

            if (_fade <= 0f)
            {
                _fade = 0f;
                _isDissolving = false;
            }
            // TODO: Possible race condition between all animations using this matterial
            _material.SetFloat(Fade, _fade);
        }
        else
        {
            animator.SetBool(IsDissolving, false);
        }
        
    }

}