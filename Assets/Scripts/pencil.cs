using UnityEngine;

public class pencil : MonoBehaviour
{
    public float B = 1.5f;

    void Update()
    {
        transform.localScale = new Vector3(1f, B, 1f);
    }
}
