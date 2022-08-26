using UnityEngine;
using UnityEngine.UI;

public class Puck : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Button hitButton;
    [SerializeField] private CameraRaycast camRay;
    [SerializeField] private GoalKeeper goalKeeper;
    [SerializeField] private Image powerBar;
    private bool _isPowerIncreasing;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        hitButton.onClick.AddListener(HitPuck);
    }

    private void Update()
    {
        CheckMaxPosition();
        MoveSlider();
        CheckDirection();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Revival();
        camRay.hits = 0;
        if (!collision.gameObject.CompareTag("Gates"))
        {
            health.TakeDamage();
        }
    }

    private void HitPuck()
    {
        if (camRay.hits == 1)
        {
            _rb.isKinematic = false;
            var direction = camRay.targetPoint - _rb.position;
            _rb.velocity = direction.normalized * powerBar.fillAmount * 20f;
            hitButton.interactable = false;
            camRay.targetPoint = new Vector3(0f, 0f, 0f);
            goalKeeper.moveSpeed += 0.5f;
            camRay.hits = 0;
        }
    }

    private void MoveSlider()
    {
        if (_isPowerIncreasing)
        {
            powerBar.fillAmount += 0.02f;
        }
        else
        {
            powerBar.fillAmount -= 0.02f;
        }
    }

    private void CheckDirection()
    {
        if (powerBar.fillAmount <= 0.2f)
        {
            _isPowerIncreasing = true;
        }
        else if (powerBar.fillAmount >= 1f)
        {
            _isPowerIncreasing = false;
        }
    }

    public void Revival()
    {
        var puckClone = Instantiate(gameObject, new Vector3(0f, 0.8f, -3.3f), Quaternion.identity);
        puckClone.gameObject.name = "Puck";
        Destroy(gameObject);
        hitButton.interactable = true;
    }

    private void CheckMaxPosition()
    {
        if (transform.position.magnitude > 10f)
        {
            health.TakeDamage();
            Revival();
        }
    }
}