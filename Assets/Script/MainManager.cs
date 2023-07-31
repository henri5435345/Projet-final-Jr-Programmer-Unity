using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// INHERITANCE 
// MainManager = parent - bonus buttons in shop = childs (+10, +1K, +100K)

// POLYMORPHISM - 3 bonus buttons behave differently for cost to buy and clicks bonus

public class MainManager : MonoBehaviour
{
    public double click;
    public double circleCost = 100;
    public double triangleCost = 1000;
    public double diamondCost = 1000000;
    public double circleBonusClicks = 10;
    public double triangleBonusClicks = 1000;
    public double diamondBonusClicks = 100000;
    public Text count;
    public Text cpsText;
    public float cpsMeasurementDuration = 1.0f;
    private int clicksInMeasurement;
    private float cpsTimer;
    private float currentCPS;
    private int totalClicksInMeasurement;
    private bool measuringCPS;
    public ChangeForm script;
    public Text CurrentPlayerName;
    public FormManager formManager;

    public static MainManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        SetCount();
        script = FindObjectOfType<ChangeForm>();
        CurrentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        formManager = FindObjectOfType<FormManager>();
        formManager.SetInitialForm();
        currentCPS = 0f;
        cpsText.text = "CPS : 0";
        measuringCPS = false;
    }

    public void Update()
    {
        if (measuringCPS)
        {
            cpsTimer += Time.deltaTime;
            clicksInMeasurement++;

            if (cpsTimer >= cpsMeasurementDuration)
            {
                currentCPS = totalClicksInMeasurement / cpsMeasurementDuration;
                cpsText.text = "CPS : " + currentCPS.ToString("F1");
                totalClicksInMeasurement = 0;
                cpsTimer = 0f;
                measuringCPS = false;
            }
        }
    }

    public void Click()
    {
        click += GetClickBonus();
        totalClicksInMeasurement++;
        SetCount();// ABSTRACTION
        script.ChangeForm2();
    }

    private double GetClickBonus()
    {
        double bonus = 1;
        if (formManager.HasPurchasedCircle)
        {
            bonus += circleBonusClicks * formManager.circleBonusCount;
        }
        if (formManager.HasPurchasedTriangle)
        {
            bonus += triangleBonusClicks;
        }
        if (formManager.HasPurchasedDiamond)
        {
            bonus += diamondBonusClicks;
        }
        return bonus;
    }

    public void BuyCircle()
    {
        if (click >= circleCost)
        {
            click -= circleCost;
            formManager.HasPurchasedCircle = true;
            formManager.circleBonusCount++;
            SetCount();// ABSTRACTION
        }
        else
        {
            Debug.Log("Tu n'as pas assez de click pour acheter le cercle !");
        }
    }

    public void BuyTriangle()
    {
        if (click >= triangleCost)
        {
            click -= triangleCost;
            formManager.HasPurchasedTriangle = true;
            formManager.triangleBonusCount++;
            SetCount();// ABSTRACTION
        }
        else
        {
            Debug.Log("Tu n'as pas assez de click pour acheter le triangle !");
        }
    }

    public void BuyDiamond()
    {
        if (click >= diamondCost)
        {
            click -= diamondCost;
            formManager.HasPurchasedDiamond = true;
            SetCount(); // ABSTRACTION
        }
        else
        {
            Debug.Log("Tu n'as pas assez de click pour acheter le losange !");
        }
    }

    public void SetCount()// ABSTRACTION
    {
        count.text = "Count : " + FormatNumber(click);
    }

    private string FormatNumber(double number)
    {
        if (number >= 1e66)
        {
            return (number / 1e66).ToString("F1") + "SP";
        }
        else if (number >= 1e63)
        {
            return (number / 1e63).ToString("F1") + "SO";
        }
        else if (number >= 1e60)
        {
            return (number / 1e60).ToString("F1") + "SN";
        }
        else if (number >= 1e57)
        {
            return (number / 1e57).ToString("F1") + "SD";
        }
        else if (number >= 1e54)
        {
            return (number / 1e54).ToString("F1") + "UD";
        }
        else if (number >= 1e51)
        {
            return (number / 1e51).ToString("F1") + "DD";
        }
        else if (number >= 1e48)
        {
            return (number / 1e48).ToString("F1") + "TD";
        }
        else if (number >= 1e45)
        {
            return (number / 1e45).ToString("F1") + "QD";
        }
        else if (number >= 1e42)
        {
            return (number / 1e42).ToString("F1") + "QID";
        }
        else if (number >= 1e39)
        {
            return (number / 1e39).ToString("F1") + "SD";
        }
        else if (number >= 1e36)
        {
            return (number / 1e36).ToString("F1") + "SPD";
        }
        else if (number >= 1e33)
        {
            return (number / 1e33).ToString("F1") + "OD";
        }
        else if (number >= 1e30)
        {
            return (number / 1e30).ToString("F1") + "ND";
        }
        else if (number >= 1e27)
        {
            return (number / 1e27).ToString("F1") + "VIG";
        }
        else if (number >= 1e24)
        {
            return (number / 1e24).ToString("F1") + "UNVIG";
        }
        else if (number >= 1e21)
        {
            return (number / 1e21).ToString("F1") + "DVIG";
        }
        else if (number >= 1e18)
        {
            return (number / 1e18).ToString("F1") + "TVIG";
        }
        else if (number >= 1e15)
        {
            return (number / 1e15).ToString("F1") + "QIVIG";
        }
        else if (number >= 1e12)
        {
            return (number / 1e12).ToString("F1") + "QIVIG";
        }
        else if (number >= 1e9)
        {
            return (number / 1e9).ToString("F1") + "QIVIG";
        }
        else if (number >= 1e6)
        {
            return (number / 1e6).ToString("F1") + "M";
        }
        else if (number >= 1e3)
        {
            return (number / 1e3).ToString("F1") + "K";
        }
        else
        {
            return number.ToString();
        }
    }

    public void StartMeasuringCPS()
    {
        measuringCPS = true;
    }
}
