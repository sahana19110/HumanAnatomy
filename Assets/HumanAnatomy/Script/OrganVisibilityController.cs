using UnityEngine;

public class OrganVisibilityController : MonoBehaviour
{
    public GameObject[] allOrgans;
    public string bodyName = "Body"; // Name of the main Body object

    public void ShowOnly(string organName)
    {
        foreach (GameObject organ in allOrgans)
        {
            // Always show the Body
            if (organ.name == bodyName || organ.name == organName)
            {
                organ.SetActive(true);
            }
            else
            {
                organ.SetActive(false);
            }
        }
    }

    public void ShowAll()
    {
        foreach (GameObject organ in allOrgans)
        {
            organ.SetActive(true);
        }
    }
}
