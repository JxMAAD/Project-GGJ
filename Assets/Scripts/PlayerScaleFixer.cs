using UnityEngine;

public class PlayerScaleFixer : MonoBehaviour
{
    [Header("Scale Settings")]
    public Vector3 normalScale = Vector3.one;
    public bool fixScaleOnStart = true;
    public bool preventScaleChanges = false;
    
    [Header("Debug")]
    public bool showDebugInfo = false;
    
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
        
        if (fixScaleOnStart)
        {
            transform.localScale = normalScale;
            if (showDebugInfo)
            {
                Debug.Log($"Fixed scale from {originalScale} to {normalScale}");
            }
        }
    }

    void Update()
    {
        if (preventScaleChanges)
        {
            // Pastikan scale tidak berubah kecuali untuk flip horizontal
            Vector3 currentScale = transform.localScale;
            
            // Hanya izinkan perubahan pada X axis untuk flip
            if (Mathf.Abs(currentScale.y) != Mathf.Abs(normalScale.y) || 
                Mathf.Abs(currentScale.z) != Mathf.Abs(normalScale.z))
            {
                transform.localScale = new Vector3(
                    currentScale.x, // Biarkan X untuk flip
                    normalScale.y,  // Fix Y
                    normalScale.z   // Fix Z
                );
                
                if (showDebugInfo)
                {
                    Debug.Log($"Scale corrected to: {transform.localScale}");
                }
            }
        }
    }

    // Method untuk flip horizontal tanpa mengubah scale
    public void FlipHorizontal(bool faceRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = faceRight ? Mathf.Abs(normalScale.x) : -Mathf.Abs(normalScale.x);
        transform.localScale = scale;
    }
}