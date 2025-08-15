using UnityEngine;

public class BoundsColliders : MonoBehaviour
{
    public PlayerControls PCscript;
    public float platformLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoundBox"))
        {
            SetBoundState(other.name, false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BoundBox"))
        {
            SetBoundState(other.name, true);
        }
    }

    void SetBoundState(string boundName, bool state)
    {
        switch (boundName)
        {
            case "North": PCscript.northBounds = state; break;
            case "South": PCscript.southBounds = state; break;
            case "East":  PCscript.eastBounds = state;  break;
            case "West":  PCscript.westBounds = state;  break;
        }
    }
}
