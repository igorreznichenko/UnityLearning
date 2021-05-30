using System.Collections;
using UnityEngine;
namespace Car
{
    public class TestScript : MonoBehaviour
    {
        bool isPaused = false;
        bool isBusy = false;

        private void Awake()
        {
            Debug.Log("Awake");
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable");
        }
        void Start()
        {
            Debug.Log("OnStart");
        }
        private void OnGUI()
        {
            if (isPaused)
                GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
        }
        private void OnApplicationPause(bool pause)
        {
            isPaused = pause;
        }

        private void OnApplicationFocus(bool focus)
        {
            isPaused = !focus;
        }
        IEnumerator MakeCoroutine(float seconds)
        {
            Debug.Log("Hello");
            yield return new WaitForSeconds(seconds);
            Debug.Log("World!");
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Escape))
                Time.timeScale = 0;
            else
                if (Input.GetKey(KeyCode.K) && !isBusy)
            {
                isBusy = true;
                StartCoroutine("MakeCoroutine", 3);
            }
        }

    }
}