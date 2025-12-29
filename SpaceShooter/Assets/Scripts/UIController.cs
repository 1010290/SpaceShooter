using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player playerController;
    public Slider healthBar;

    private void Start()
    {
        healthBar.wholeNumbers = true;
        healthBar.minValue = 0;
    }
}
