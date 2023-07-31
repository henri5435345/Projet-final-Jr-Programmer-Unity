using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormManager : MonoBehaviour
{
    public bool HasPurchasedCircle { get; set; }
    public bool HasPurchasedTriangle { get; set; }
    public bool HasPurchasedDiamond { get; set; }
    public int circleBonusCount { get; set; }
    public int triangleBonusCount { get; set; }

    public int circleBonusClicksPerPurchase = 10; // Bonus de clics à ajouter à chaque achat du cercle
    public int triangleBonusMultiplier = 2; // Bonus multiplicateur à ajouter à chaque achat du triangle

    public GameObject circleImage;
    public GameObject triangleImage;
    public GameObject diamondImage;

    public void SetInitialForm()
    {
        circleImage.SetActive(true);
        triangleImage.SetActive(false);
        diamondImage.SetActive(false);
        circleBonusCount = 0;
        triangleBonusCount = 0;
    }

    public void ActivateCircle()
    {
        circleImage.SetActive(true);
        triangleImage.SetActive(false);
        diamondImage.SetActive(false);
    }

    public void ActivateTriangle()
    {
        circleImage.SetActive(false);
        triangleImage.SetActive(true);
        diamondImage.SetActive(false);
    }

    public void ActivateDiamond()
    {
        circleImage.SetActive(false);
        triangleImage.SetActive(false);
        diamondImage.SetActive(true);
    }

    public int GetBonusClicks()
    {
        int bonus = 0;
        if (HasPurchasedCircle)
        {
            bonus += circleBonusClicksPerPurchase * circleBonusCount;
        }
        if (HasPurchasedTriangle)
        {
            bonus += GetTriangleBonusClicks();
        }
        return bonus;
    }

    public int GetTriangleBonusClicks()
    {
        return (int)Mathf.Pow(triangleBonusMultiplier, triangleBonusCount);
    }
}
