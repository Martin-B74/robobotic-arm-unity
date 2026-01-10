using UnityEngine;

public class rotation_2 : MonoBehaviour {
    public float q2 = 0f;

    void Update()
    {
        transform.localEulerAngles = new Vector3(q2, 0f, 0f);
    }
}