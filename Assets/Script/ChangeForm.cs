using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    private Vector3 initialScale; 
    
    
    void Start()
    {
    
        initialScale = transform.localScale;
    }

    public void ChangeForm2()
    {
        transform.localScale *= 1.1f;
    
        StartCoroutine(ResetScaleAfterDelay());
    }

    private IEnumerator ResetScaleAfterDelay()
    {
        yield return new WaitForSeconds(0.2f);
        transform.localScale = initialScale;
    }
}
