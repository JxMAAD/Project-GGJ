using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    [Header("Animation Test")]
    public Animator animator;
    public bool enableKeyboardTest = true;
    
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (!enableKeyboardTest || animator == null) return;
        
        // Test animations with keyboard
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Testing PlayerIdle animation");
            animator.SetTrigger("PlayerIdle");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Testing PlayerRun animation");
            animator.SetTrigger("PlayerRun");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Testing PlayerJump animation");
            animator.SetTrigger("PlayerJump");
        }
    }
}