using UnityEngine;

public class rotation_1 : MonoBehaviour
{
    public float q1 = 0f;

    void Update()
    {
        transform.localEulerAngles = new Vector3(0f, q1, 0f);
    }
}