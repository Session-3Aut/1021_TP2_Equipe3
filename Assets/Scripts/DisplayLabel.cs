using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;

public class DisplayLabel : MonoBehaviour
{
    [SerializeField] private Transform rayStartPoint;
    [SerializeField] private float rayLength = 8.0f;
    [SerializeField] private MRUKAnchor.SceneLabels labelFilter;
    [SerializeField] private GameObject labelDisplay;
    [SerializeField] private TextMeshPro labelText;

    void Update()
    {
        Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();

        if(room == null){
            Debug.LogWarning("No room found");
            return;
        }

        bool hasHit = room.Raycast(ray, rayLength, new LabelFilter(labelFilter), out RaycastHit hitInfo, out MRUKAnchor anchor);
        
        if(hasHit){
            Vector3 hitPoint = hitInfo.point;
            Vector3 hitNormal = hitInfo.normal;

            string label = anchor.Label.ToString();

            labelDisplay.transform.position = hitPoint;
            labelDisplay.transform.rotation = Quaternion.LookRotation(-hitNormal);

            labelText.text =  "Anchor: " + label;
        }
    }
}
