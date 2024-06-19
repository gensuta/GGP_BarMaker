using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private Grid grid;

    [SerializeField]
    private Camera sceneCamera;

    [SerializeField]
    private LayerMask placementLayerMask;

    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCellIndicator();
    }

    public void UpdateCellIndicator()
    {
        Vector3 mousePos = GetSelectedMapPosition();
        mousePos.y = 0.5f;
        Vector3Int gridPosition = grid.WorldToCell(mousePos);
        mouseIndicator.transform.position = mousePos;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 currentMousePos = Input.mousePosition;
        currentMousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(currentMousePos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 350, placementLayerMask))
        {
            lastPosition = hit.point;
        }


        return lastPosition;
    }
}
