using UnityEngine;

public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject[] placedPrefab;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private LayerMask placedObjectLayerMask;
    private Vector2 touchPosition;
    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        // 화면이 터치되지 않았거나 터치가 Began 상태가 아니면 종료
        if (!Utility.TryGetInputPosition(out touchPosition)) return;

        // 오브젝트 선택(select)
        ray = arCamera.ScreenPointToRay(touchPosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, placedObjectLayerMask))
        {
            PlacedObject.SelectedObject = hit.transform.GetComponentInChildren<PlacedObject>();
            return;
        }

        PlacedObject.SelectedObject = null; // 오브젝트 선택 취소

        if (Utility.Raycast(touchPosition, out Pose hitPose))
        {
            int index = Random.Range(0, placedPrefab.Length);
            Instantiate(placedPrefab[index], hitPose.position, hitPose.rotation);
        }
    }
}
