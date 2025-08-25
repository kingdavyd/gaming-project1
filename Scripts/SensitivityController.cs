using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour
{
    public Slider sensitivitySlider; // Reference to the slider UI element
    public Text sensitivityText; // Optional: Reference to a Text UI element to display sensitivity value

    private const string sensitivityKey = "Sensitivity"; // Key to store sensitivity in PlayerPrefs
    private float defaultSensitivity = 5f; // Default sensitivity value

    void Start()
    {
        // Set default sensitivity or get the saved sensitivity value from PlayerPrefs
        float sensitivity = PlayerPrefs.GetFloat(sensitivityKey, defaultSensitivity);
        sensitivitySlider.value = sensitivity;

        // Subscribe to the slider's OnValueChanged event
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }

    // Function to update sensitivity based on the slider value
    void UpdateSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat(sensitivityKey, sensitivity); // Save sensitivity value to PlayerPrefs
        PlayerPrefs.Save(); // Save PlayerPrefs data

        // Optional: Update UI to display sensitivity value
        if (sensitivityText != null)
        {
            sensitivityText.text = "Sensitivity: " + sensitivity.ToString();
        }
    }
}
