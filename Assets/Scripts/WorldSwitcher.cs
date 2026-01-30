using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject worldDark;
    public GameObject worldLight;

    private bool isDark = true;

    void Start()
    {
        worldDark.SetActive(true);
        worldLight.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isDark = !isDark;

            worldDark.SetActive(isDark);
            worldLight.SetActive(!isDark);
        }
    }
}
