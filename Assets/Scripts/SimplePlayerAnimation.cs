using UnityEngine;

public class SimplePlayerAnimation : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    
    [Header("Debug")]
    public bool showDebugInfo = true;
    
    private PlayerMovement playerMovement;
    private string lastAnimation = "";

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
            
        playerMovement = GetComponent<PlayerMovement>();
        
        if (animator == null)
        {
            Debug.LogError("Animator not found on " + gameObject.name);
        }
        
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (animator == null || playerMovement == null) return;
        
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        string targetAnimation = "";
        
        // Cek input untuk menentukan animasi
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f;
        bool isJumping = Input.GetKey(KeyCode.Space);
        
        // Tentukan animasi berdasarkan input
        if (isJumping)
        {
            targetAnimation = "PlayerJump";
        }
        else if (isMoving)
        {
            targetAnimation = "PlayerRun";
        }
        else
        {
            targetAnimation = "PlayerIdle";
        }
        
        // Hanya trigger jika animasi berubah
        if (targetAnimation != lastAnimation)
        {
            if (showDebugInfo)
            {
                Debug.Log($"Playing animation: {targetAnimation}");
            }
            
            // Reset semua triggers dulu
            animator.ResetTrigger("PlayerIdle");
            animator.ResetTrigger("PlayerRun");
            animator.ResetTrigger("PlayerJump");
            
            // Set trigger yang baru
            animator.SetTrigger(targetAnimation);
            lastAnimation = targetAnimation;
        }
    }
}