using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] private int targetersAmount;

    private Renderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
    }

    public void IncrementTargeters()
    {
        targetersAmount++;
        CheckStatus();
    }

    public void DecreaseTargeters()
    {
        targetersAmount--;
        CheckStatus();
    }

    private void CheckStatus()
    {
        if (targetersAmount > 0)
        {
            myRenderer.material.SetColor("_Color", Color.magenta);
        }
        else
        {
            myRenderer.material.SetColor("_Color", Color.cyan);
        }
    }
}
