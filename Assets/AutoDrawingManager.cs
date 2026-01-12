using UnityEngine;

public class AutoDrawingManager : MonoBehaviour
{
    public ArmController controller;
    public CircleDrawer circleDrawer;
    public LineDrawer lineDrawer;
    public LetterByLetterDrawer textDrawer;

    public void SliderMode()
    {
        if (controller != null)
            controller.slider = true;
        if (circleDrawer != null)
            circleDrawer.enabled = false;
        if (lineDrawer != null)
            lineDrawer.enabled = false;
        if (textDrawer != null)
            textDrawer.enabled = false;
    }

    public void AutoCircle()
    {
        if (controller != null)
            controller.slider = false;
        if (lineDrawer != null)
            lineDrawer.enabled = false;
        if (textDrawer != null)
            textDrawer.enabled = false;
        if (circleDrawer != null)
        {
            circleDrawer.enabled = true;
            circleDrawer.StartDrawing();
        }
        else
        {
            Debug.LogError("CircleDrawer is null !");
        }
    }


    public void AutoLine()
    {
        if (controller != null)
            controller.slider = false;
        if (circleDrawer != null)
            circleDrawer.enabled = false;
        if (textDrawer != null)
            textDrawer.enabled = false;
        if (lineDrawer != null)
        {
            lineDrawer.enabled = true;
            lineDrawer.StartDrawing();
        }
        else
        {
            Debug.LogError("LineDrawer is null !");
        }
    }


    public void AutoText()
    {
        controller.slider = false;

        circleDrawer.enabled = false;
        lineDrawer.enabled = false;

        textDrawer.enabled = true;
        textDrawer.StartDrawing();
    }
}
