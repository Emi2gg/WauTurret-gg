using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
    private GameObject _turretPrefab = null;
    private int _cost = 0;

    
    public void OnTurretChange((GameObject prefab, int cost) turret)
    {
        _cost = turret.cost;
        _turretPrefab = turret.prefab;
    }
    void Update()
    {
        if(_turretPrefab == null && _cost == 0) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity,
                    LayerMask.GetMask("Placement")))
            {
                var hitTransform = hit.collider.transform;
                if (!hitTransform.GetComponent<TurretSlot>().IsOccupied)
                {
                    if (GameManager.Instance.TrySpendCurrency(_cost))
                    {

                        var positionVector = new Vector3(hitTransform.position.x, hit.point.y,
                            hitTransform.position.z);
                        EventDispatcher.Dispatch(
                            new SpawnObject(_turretPrefab, null, positionVector,
                                Quaternion.identity,
                                o =>
                                {
                                    hitTransform.GetComponent<TurretSlot>().SetTurret(o);
                                } ));
                        hitTransform.GetComponent<TurretSlot>().SetStatus(true);
                    }
                }
                else
                {
                    if (_turretPrefab == null)
                    {
                        var t = hitTransform.GetComponent<TurretSlot>().Turret;
                        EventDispatcher.Dispatch(
                            new DespawnObject(t));
                        hitTransform.GetComponent<TurretSlot>().SetStatus(false);
                    }
                }
            }
        }
    }
}
