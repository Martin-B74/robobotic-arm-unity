using UnityEngine;

public class rotation_3 : MonoBehaviour
{
    public float q4 = 0f;

    void Update()
    {
        transform.localEulerAngles = new Vector3(-q4, 0f, 0f);
    }
}