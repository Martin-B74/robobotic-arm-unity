using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    public ArmController controller;
    public CircleDrawer circleDrawer;

    public void SetSliderMode()
    {
        controller.slider = true;
    }

    public void SetAutoMode()
    {
        controller.slider = false;
    }

}
