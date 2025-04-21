using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeSelectButton : MonoBehaviour {
    [SerializeField] private Color defColor = new Color(1f, 1f, 1f, 0.5f);
    [SerializeField] private Color activeColor = new Color(1f, 0.88f, 0f, 0.5f);

    [SerializeField] private TextMeshProUGUI nameLabel;
    [SerializeField] private RectTransform nameLabelRectTransform;
    [SerializeField] private Image icon;
    [SerializeField] private RectTransform iconRectTransform;
    [SerializeField] private Image background;
    [SerializeField] private Button button;

    private int cubeType;

    private void Start()
    {
        button.onClick.AddListener(Clicked);
    }

    private void Update()
    {
        background.color = CubeManager.Instance.SelectedFlower == cubeType ? activeColor : defColor;
    }

    public void Set(int cubeType)
    {
        // Label
        nameLabel.text = CubeManager.Instance.CubeList.cubes[cubeType].name;
        nameLabel.fontSize = 28;
        nameLabel.alignment = TextAlignmentOptions.Center;
        nameLabel.color = Color.black;
        nameLabel.raycastTarget = false;

        nameLabelRectTransform.anchorMin = new Vector2(0, 0);
        nameLabelRectTransform.anchorMax = new Vector2(1, 0);
        nameLabelRectTransform.pivot = new Vector2(0.5f, 0);

        // sprite
        icon.sprite = CubeManager.Instance.CubeList.cubePreviews[cubeType];
        icon.preserveAspect = true;
        //iconRectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        iconRectTransform.localScale = new Vector3(2f, 2f, 2f);

        // cubeType
        this.cubeType = cubeType;
    }

    private void Clicked()
    {
        CubeManager.Instance.SelectedFlower = cubeType;
    }
}