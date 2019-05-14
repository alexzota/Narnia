using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Class <c>Stat</c> defines a stat and its in-game bar
/// </summary>
public class Stat : MonoBehaviour
{
    /// <summary>
    /// Image to be displayed on the in-game bar
    /// </summary>
    private Image content;
    /// <summary>
    /// Speed for smooth in-game bar decrease/increase
    /// </summary>
    private float lerpSpeed = 5F;
    /// <summary>
    /// The maximum value of the stat
    /// </summary>
    private float maxValue;
    /// <summary>
    /// The current value of the stat
    /// </summary>
    [SerializeField]
    private float currentValue;
    /// <summary>
    /// The current fill amount of the stat
    /// </summary>
    private float currentFill;

    /// <summary> 
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        content = GetComponent<Image>();
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    /// <summary>
    /// Indicates whether the stat's current value is equal to its maximum value.
    /// </summary>
    /// <returns>True if the stat is at maximum value and false otherwise</returns>
    public bool IsFull()
    {
        return currentValue == maxValue;
    }

    /// <summary>
    /// Indicates whether the stat`s current value is 0.
    /// </summary>
    /// <returns>True if the stat's current value is 0 and false otherwise</returns>
    public bool IsEmpty()
    {
        return currentValue == 0;
    }

    /// <summary>
    /// Decreases the stat's current value by an amount equal to <paramref name="amount"/>.
    /// </summary>
    /// <param name="amount">The value to be subtracted from the stat</param>
    public void Decrease(float amount)
    {
        currentValue -= amount;
        if (currentValue < 0)
            currentValue = 0;
        currentFill = currentValue / maxValue;
    }

    /// <summary>
    /// Increases the stat's current value by an amount equal to <paramref name="amount"/>.
    /// </summary>
    /// <param name="amount">The value to be added to the stat</param>
    public void Increase(float amount)
    {
        currentValue += amount;
        if (currentValue > maxValue)
            currentValue = maxValue;
        currentFill = currentValue / maxValue;
    }

    /// <summary>
    /// Initializes the stat with its current and maximum value.
    /// </summary>
    /// <param name="currentValue">The stat's current value</param>
    /// <param name="maxValue">The stat's maximum value</param>
    public void Initialize(float currentValue, float maxValue)
    {
        this.maxValue = maxValue;
        this.currentValue = currentValue;
        this.currentFill = this.currentValue / this.maxValue;
    }
}
