using UnityEngine;

public class MonkeyAnims : MonoBehaviour
{
    public static MonkeyAnims instance;
    [SerializeField] private Animator redAnimator, blueAnimator;
    private int _jumpID, _runID, _idleID;

    private void Awake()
    {
        instance = this;
        
        _jumpID = Animator.StringToHash("Jump");
        _runID = Animator.StringToHash("Run");
        _idleID = Animator.StringToHash("Idle");
    }

    private static bool _run = false, _jump = false;
    
    public void SetRunning() { _run = true;  }
    public void EndRunning() { _run = false; }

    public void SetJumping() { _jump = true;  }
    public void EndJumping() { _jump = false; }

    private void Update()
    {
        if (_jump)
        {
            if (MonkeyStateSwitcher.instance.IsRed())
            {
                redAnimator.SetTrigger(_jumpID);
            }
            else
            {
                blueAnimator.SetTrigger(_jumpID);
            }
        }
        else if (_run)
        {
            if (MonkeyStateSwitcher.instance.IsRed())
            {
                redAnimator.SetTrigger(_runID);
            }
            else
            {
                blueAnimator.SetTrigger(_runID);
            }
        }
        else
        {
            if (MonkeyStateSwitcher.instance.IsRed())
            {
                redAnimator.SetTrigger(_idleID);
            }
            else
            {
                blueAnimator.SetTrigger(_idleID);
            }
        }
    }
}
