using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    [SerializeField] private ObjectFactory _objectFactory;
    [SerializeField] private Detonator _detonator;

    private int _mouseButton = 0;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Employ();
    }

    private void Employ()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            Ray ray = _camera.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));            

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.TryGetComponent(out Specifications specifications))
                {
                    if (specifications.CanAppear())
                        _objectFactory.GenerateObjects(specifications);
                    else
                        _detonator.Explode(specifications.transform , specifications.ExplosionForce, specifications.ExplosionRadius);

                    Destroy(specifications.gameObject);
                }
            }
        }
    }
}
