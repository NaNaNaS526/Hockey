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
        MoveSlider();
        CheckDirection();
        if (transform.position.magnitude > 10f)
        {
            health.TakeDamage();
            Revival();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        camRay.hits = 0;
        Revival();
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
        }
    }

    private void MoveSlider()
    {
        if (_isPowerIncreasing)
        {
            powerBar.fillAmount += 0.05f;
        }
        else
        {
            powerBar.fillAmount -= 0.05f;
        }
    }

    private void CheckDirection()
    {
        if (powerBar.fillAmount <= 0f)
        {
            _isPowerIncreasing = true;
        }
        else if (powerBar.fillAmount >= 1f)
        {
            _isPowerIncreasing = false;
        }
    }

    private void Revival()
    {
        var puckClone = Instantiate(gameObject, new Vector3(0f, 0.8f, -3.3f), Quaternion.identity);
        puckClone.gameObject.name = "Puck";
        Destroy(gameObject);
        hitButton.interactable = true;
    }
}