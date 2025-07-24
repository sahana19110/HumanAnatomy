using UnityEngine;
using TMPro;

public class OrganPopupManager : MonoBehaviour
{
    [System.Serializable]
    public class OrganInfo
    {
        public string organName;
        [TextArea] public string description;
        public Transform popupPosition;
        public AudioClip audioClip; // 🔊 Audio for this organ
    }

    [Header("Organ Data")]
    public OrganInfo[] organs;

    [Header("Popup UI")]
    public GameObject popupPanel;
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    [Header("Audio")]
    public AudioSource audioSource; // Assign this in Inspector

    public void ShowPopup(string organName)
    {
        foreach (OrganInfo organ in organs)
        {
            if (organ.organName == organName)
            {
                // Show popup
                popupPanel.SetActive(true);
                popupPanel.transform.position = organ.popupPosition.position;

                // Rotate toward player camera (flattened)
                Vector3 directionToCamera = popupPanel.transform.position - Camera.main.transform.position;
                directionToCamera.y = 0;
                popupPanel.transform.rotation = Quaternion.LookRotation(directionToCamera);

                // Set popup text
                titleText.text = organ.organName;
                descriptionText.text = organ.description;

                // Play audio
                if (audioSource != null && organ.audioClip != null)
                {
                    audioSource.Stop(); // Stop if anything already playing
                    audioSource.clip = organ.audioClip;
                    audioSource.Play();
                }

                break;
            }
        }
    }

    public void HidePopup()
    {
        popupPanel.SetActive(false);

        // Stop audio
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
