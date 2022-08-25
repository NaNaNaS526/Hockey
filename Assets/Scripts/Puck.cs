using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Puck : MonoBehaviour
{
    [SerializeField] private Button hitButton;
    [SerializeField] private CameraRaycast camRay;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.position = new Vector3(0f, 0.8f, -3.3f);
    }

    private void HitPuck()
    {
        _rb.isKinematic = false;
        var direction = camRay.targetPoint - _rb.position;
        _rb.velocity = direction.normalized * powerBar.fillAmount * 10f;
        camRay.hits = 0;
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
}