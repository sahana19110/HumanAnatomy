using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject mainMenuPanel;
    public GameObject humanAnatomyPanel;
    public GameObject brainUIPanel; // ✅ Assigned in Inspector
    public GameObject brainExplosionObject;
    public GameObject cameraRig; // Your XR Rig
    public Transform humanAnatomyPoint;
    public Transform brainPoint;
    public Transform menuTeleportPoint; // ✅ Add this in the scene and assign in Inspector

    void Start()
    {
        ShowStartPanel();
    }

    public void ShowStartPanel()
    {
        startPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        humanAnatomyPanel.SetActive(false);
        brainExplosionObject.SetActive(false);
        brainUIPanel.SetActive(false); // ✅ Hide brain panel on start
    }

    public void OnStartClicked()
    {
        startPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void OnHumanAnatomyClicked()
    {
        mainMenuPanel.SetActive(false);
        humanAnatomyPanel.SetActive(true);

        Vector3 targetPosition = humanAnatomyPoint.position;
        targetPosition.y = cameraRig.transform.position.y; 
        cameraRig.transform.position = targetPosition;
        cameraRig.transform.rotation = humanAnatomyPoint.rotation;
    }

    public void OnBrainClicked()
    {
        mainMenuPanel.SetActive(false);
        brainExplosionObject.SetActive(true);
        brainUIPanel.SetActive(true); // ✅ Show the brain UI with Back button

        // Teleport to brain
        Vector3 targetPosition = brainPoint.position;
        targetPosition.y = cameraRig.transform.position.y; // keep current height
        cameraRig.transform.position = targetPosition;
        cameraRig.transform.rotation = brainPoint.rotation;

        Animator brainAnimator = brainExplosionObject.GetComponent<Animator>();
        if (brainAnimator != null)
        {
            brainAnimator.SetTrigger("Explode");
        }
    }

    public void BackToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        humanAnatomyPanel.SetActive(false);
        brainExplosionObject.SetActive(false);
        brainUIPanel.SetActive(false); // ✅ Hide brain UI panel

        // Optional: teleport back to menu position
        Vector3 targetPosition = menuTeleportPoint.position;
        targetPosition.y = cameraRig.transform.position.y; // maintain headset height
        cameraRig.transform.position = targetPosition;
        cameraRig.transform.rotation = menuTeleportPoint.rotation;

    }
}
