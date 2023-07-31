using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape
{
    public abstract string Name { get; }
    public abstract float Area { get; }

    public abstract void DisplayInfo();
}

public class Circle : Shape
{
    private readonly float radius;

    public Circle(float radius)
    {
        this.radius = radius;
    }

    public override string Name { get { return "Circle"; } }

    public override float Area
    {
        get { return Mathf.PI * radius * radius; }
    }

    public override void DisplayInfo()
    {
        Debug.Log($"Shape: {Name}, Area: {Area}");
    }
}

public class Triangle : Shape
{
    private readonly float sideLength;
    private int clickCount = 0;

    public Triangle(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public override string Name { get { return "Triangle"; } }

    public override float Area
    {
        get { return (Mathf.Sqrt(3) / 4) * sideLength * sideLength; }
    }

    public override void DisplayInfo()
    {
        Debug.Log($"Shape: {Name}, Area: {FormatNumber(Area)}, Cost: {FormatNumber(GetCost())}");
    }

    private string FormatNumber(float number)
    {
        if (number >= 1000f)
        {
            return (number / 1000f).ToString("F1") + "k";
        }
        else
        {
            return number.ToString();
        }
    }

    public int GetCost()
    {
        return 1000 + (clickCount * 1000);
    }

    public void IncreaseClickCount()
    {
        clickCount++;
    }
}

public class Diamond : Shape
{
    private readonly float width;
    private readonly float height;
    private int clickCount = 0;

    public Diamond(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

    public override string Name { get { return "Diamond"; } }

    public override float Area
    {
        get { return width * height; }
    }

    public override void DisplayInfo()
    {
        Debug.Log($"Shape: {Name}, Area: {FormatNumber(Area)}, Cost: {FormatNumber(GetCost())}");
    }

    private string FormatNumber(float number)
    {
        if (number >= 1000f)
        {
            return (number / 1000f).ToString("F1") + "k";
        }
        else if (number >= 1000000f)
        {
            return (number / 1000000f).ToString("F1") + "M";
        }
        else
        {
            return number.ToString();
        }
    }

    public int GetCost()
    {
        return 1000000 + (clickCount * 10000);
    }

    public void IncreaseClickCount()
    {
        clickCount++;
    }
}
