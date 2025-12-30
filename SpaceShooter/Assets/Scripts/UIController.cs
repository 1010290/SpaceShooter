using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player shipController;
    public Slider healthBar;
    public Image healthBarFill;
    public Color[] fillColor = new Color[3];

    private void Start()
    {
        //sets value of health bar to whole numbers
        healthBar.wholeNumbers = true;
        //sets minimum value of healthbar to zero
        healthBar.minValue = 0;

        fillColor[0] = new Color(0, 255, 0);
        fillColor[1] = new Color(255, 194, 0);
        fillColor[2] = new Color(255, 0, 0);
    }

    private void Update()
    {
        healthBar.maxValue = shipController.stats.maxHealth;
        healthBar.value = shipController.stats.currentHealth;

        healthBarFill.color = fillColor[0];
        if(healthBar.value <= 80)
            healthBarFill.color = fillColor[1];
        if(healthBar.value <= 40)
            healthBarFill.color = fillColor[2];
    }
}
