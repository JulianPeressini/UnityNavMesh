using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{

    [SerializeField] private int targetersAmount;

    public int TargetersAmount { get { return targetersAmount;} }

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
        switch (targetersAmount)
        {
            case 0:
                myRenderer.material.SetColor("_Color", Color.cyan);
                break;

            case 1:
                myRenderer.material.SetColor("_Color", Color.yellow);
                break;

            case 2:
                myRenderer.material.SetColor("_Color", Color.magenta);
                break;

            case 3:
                myRenderer.material.SetColor("_Color", Color.red);
                break;
        }
    }
}
