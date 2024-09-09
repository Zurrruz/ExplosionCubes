using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    [SerializeField] ObjectFactory _objectFactory;
    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        Employ();
    }

    private void Employ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.gameObject.TryGetComponent(out Detonator detonator))
                {
                    if (detonator.CanAppear())
                        _objectFactory.GenerateObjects(detonator.transform, detonator.ChanceDecay);

                    Destroy(detonator.gameObject);
                }
            }
        }
    }
}
