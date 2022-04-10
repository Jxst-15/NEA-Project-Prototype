using UnityEngine;

public class Pausing : MonoBehaviour
{
    public bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused == true)
        {
            Time.timeScale = 0f;
            paused = true;
        }
    }
}
