using UnityEngine;

public class Pausing : MonoBehaviour
{
    public bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
               Time.timeScale = 1;
            }
            else
            {
               Time.timeScale = 0;
               Debug.Log("Paused");
            }
            paused = !paused;
        }
    }
}
