using UnityEngine;

public class AutoDrawingManager : MonoBehaviour
{
    public ArmController controller;
    public CircleDrawer circleDrawer;
    public LineDrawer lineDrawer;

    public void SliderMode()
    {
        controller.slider = true;

        circleDrawer.enabled = false;
        lineDrawer.enabled = false;
    }

    public void AutoCircle()
    {
        controller.slider = false;

        lineDrawer.enabled = false;

        circleDrawer.enabled = true;
        circleDrawer.ResetDrawing();
    }

    public void AutoLine()
    {
        controller.slider = false;

        circleDrawer.enabled = false;

        lineDrawer.enabled = true;
        lineDrawer.ResetDrawing();
    }
}
