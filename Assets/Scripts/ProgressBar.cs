using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] TalentPanelManager talentPanel;
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/Linear Progress Bar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("UI/Linear Progress Bar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }
#endif

    public int minimum;      
    public int maximum;      
    public int current;      
    public Image mask;       // The mask image that represents the fill amount
    public Image fill;       // The fill image of the progress bar
    public Color color;      // The color of the fill image
    public float ExpIncrease;
    public GameObject levelUpPanel;  // The panel to enable when the maximum is reached


    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;                  // Calculate the offset between current and minimum
        float maximumOffset = maximum - minimum;                  // Calculate the offset between maximum and minimum
        float fillAmount = currentOffset / maximumOffset;         // Calculate the fill amount based on the current and maximum offset

        if (current >= maximum) // When Player Levels up
        {
            fillAmount = 0f;                                      
            current = minimum;                                    
            maximum = Mathf.RoundToInt(maximum * ExpIncrease);           // Increase the maximum value by ExpIncrease
            talentPanel.OpenPanel();                                // Open the talent panel                           
        }

        mask.fillAmount = fillAmount;                             // Set the fill amount of the mask image
        fill.color = color;                                       // Set the color of the fill image
    }
}
