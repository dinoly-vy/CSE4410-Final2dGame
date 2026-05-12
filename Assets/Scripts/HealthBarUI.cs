using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarUI : MonoBehaviour
{
    private UIDocument document;
    private VisualElement root;
    private VisualElement healthBarFill;

    [SerializeField] private float maxFillWidth = 340f;

    private void OnEnable()
    {
        document = GetComponent<UIDocument>();

        if (document == null)
        {
            Debug.LogError("UIDocument is missing from HealthHUD.");
            return;
        }

        root = document.rootVisualElement;

        healthBarFill = root.Q<VisualElement>("HealthBarFill");

        if (healthBarFill == null)
        {
            Debug.LogError("HealthBarFill was not found. Check the Name field in UI Builder.");
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthBarFill == null)
            return;

        float healthPercent = Mathf.Clamp01((float)currentHealth / maxHealth);
        float newWidth = maxFillWidth * healthPercent;

        healthBarFill.style.width = newWidth;
    }

    public void HideHealthBar()
    {
        if (root != null)
            root.style.display = DisplayStyle.None;
    }

    public void ShowHealthBar()
    {
        if (root != null)
            root.style.display = DisplayStyle.Flex;
    }
}