using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    [Header("Animation Settings")]
    public string idleTrigger = "PlayerIdle";
    public string runTrigger = "PlayerRun";
    public string jumpTrigger = "PlayerJump";
    
    [Header("Debug")]
    public bool showDebugLogs = false;
    
    private Animator animator;
    private string currentAnimation = "";

    void Start()
    {
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("Animator component not found on " + gameObject.name);
        }
    }

    public void PlayIdle()
    {
        if (currentAnimation != idleTrigger)
        {
            if (showDebugLogs) Debug.Log("Playing Idle Animation");
            animator.SetTrigger(idleTrigger);
            currentAnimation = idleTrigger;
        }
    }

    public void PlayRun()
    {
        if (currentAnimation != runTrigger)
        {
            if (showDebugLogs) Debug.Log("Playing Run Animation");
            animator.SetTrigger(runTrigger);
            currentAnimation = runTrigger;
        }
    }

    public void PlayJump()
    {
        if (currentAnimation != jumpTrigger)
        {
            if (showDebugLogs) Debug.Log("Playing Jump Animation");
            animator.SetTrigger(jumpTrigger);
            currentAnimation = jumpTrigger;
        }
    }

    // Method untuk dipanggil dari PlayerMovement
    public void UpdateAnimation(bool isMoving, bool isGrounded, float velocityY)
    {
        if (animator == null) return;

        // Set animator parameters
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("velocityY", velocityY);

        // Determine which animation to play
        if (!isGrounded)
        {
            PlayJump();
        }
        else if (isMoving)
        {
            PlayRun();
        }
        else
        {
            PlayIdle();
        }
    }
}