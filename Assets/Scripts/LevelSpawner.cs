using Meta.XR.MRUtilityKit;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public static LevelSpawner Instance{get; private set;}

    [SerializeField] private GameObject level;
    [SerializeField] private OVRInput.Button spawnButton;
    [SerializeField] private Transform rayStartPoint;
    [SerializeField] private float rayLength = 8f;
    [SerializeField] private MRUKAnchor.SceneLabels labelFilter;

    

    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
        }
    }
    void Update()
    {
        HandleControllerActions(OVRInput.Controller.RTouch);
    }
    
    private void HandleControllerActions(OVRInput.Controller controller){
        if(OVRInput.GetDown(spawnButton, controller)){
            Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);

            MRUKRoom room = MRUK.Instance.GetCurrentRoom();

            bool hasHit = room.Raycast(ray, rayLength, LabelFilter.Included(labelFilter), out RaycastHit hitInfo, out MRUKAnchor anchor);

            if(hasHit){
                Vector3 hitPoint = hitInfo.point;
                Vector3 hitNormal = hitInfo.normal;

                Instantiate(level, hitPoint, Quaternion.Euler(hitNormal));
            }
        }
    }

}
