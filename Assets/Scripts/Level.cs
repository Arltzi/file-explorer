using UnityEngine;

public class Level : MonoBehaviour
{
    private bool isBuildPhase = true;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool IsBuildPhase()
    {
        return isBuildPhase;
    }

    void BuildToPlatform()
    {
        isBuildPhase = false;
    }

    void PlatformToBuild()
    {
        isBuildPhase = true;
    }
}
