using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;
    private float lerpSpeed = 5F;
    private float maxValue;
    [SerializeField]
    private float currentValue;
    private float currentFill;

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public bool IsFull()
    {
        return currentValue == maxValue;
    }

    public bool IsEmpty()
    {
        return currentValue == 0;
    }

    public void Decrease(float value)
    {
        currentValue -= value;
        if (currentValue < 0)
            currentValue = 0;
        currentFill = currentValue / maxValue;
    }

    public void Increase(float value)
    {
        currentValue += value;
        if (currentValue > maxValue)
            currentValue = maxValue;
        currentFill = currentValue / maxValue;
    }

    public void Initialize(float currentValue, float maxValue)
    {
        this.maxValue = maxValue;
        this.currentValue = currentValue;
        this.currentFill = this.currentValue / this.maxValue;
    }
}
