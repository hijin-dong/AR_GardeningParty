using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class LightEstimationText : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager arCameraManager;

    [SerializeField]
    private TMP_Text brightnessValue;

    [SerializeField]
    private TMP_Text colorCorrectionValue;

    private Light currentLight;

    private void Awake()
    {
        currentLight = GetComponent<Light>();
    }

    private void OnEnable()
    {
        arCameraManager.frameReceived += FrameUpdated;
    }

    private void OnDisable()
    {
        arCameraManager.frameReceived -= FrameUpdated;
    }
    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        if (args.lightEstimation.averageBrightness.HasValue) // 광원의 평균 밝기
        {
            brightnessValue.text = $"Brightness: {args.lightEstimation.averageBrightness.Value}";
            currentLight.intensity = args.lightEstimation.averageBrightness.Value;
        }

        if (args.lightEstimation.colorCorrection.HasValue) // 색상 보정값
        {
            colorCorrectionValue.text = $"Color: {args.lightEstimation.colorCorrection.Value}";
            currentLight.color = args.lightEstimation.colorCorrection.Value;
        }
    }
}