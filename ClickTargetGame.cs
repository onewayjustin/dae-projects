using UnityEngine;
using UnityEngine.UI;

public class ClickTargetGame : MonoBehaviour
{
    public GameObject target;                // The 3D sphere target
    public Text feedbackText;               // UI Text for feedback
    public AudioSource audioSource;         // Audio Source
    public AudioClip hitSound;              // Hit audio

    private float feedbackTimer = 0f;
    private float feedbackDuration = 1f;

    void Start()
    {
        feedbackText.text = "";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == target)
                {
                    ShowFeedback("Hit!", Color.green);
                    PlaySound();
                    MoveTargetRandomly();
                }
                else
                {
                    ShowFeedback("Miss!", Color.red);
                }
            }
            else
            {
                ShowFeedback("Miss!", Color.red);
            }
        }

        if (feedbackText.text != "")
        {
            feedbackTimer += Time.deltaTime;
            if (feedbackTimer > feedbackDuration)
            {
                feedbackText.text = "";
                feedbackTimer = 0f;
            }
        }
    }

    void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;
        feedbackTimer = 0f;
    }

    void PlaySound()
    {
        if (audioSource && hitSound)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }

    void MoveTargetRandomly()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(1f, 4f);
        float z = Random.Range(-5f, 5f);

        target.transform.position = new Vector3(x, y, z);
    }
}
