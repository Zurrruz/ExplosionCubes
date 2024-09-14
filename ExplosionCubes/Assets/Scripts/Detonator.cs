using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour{

    public void Explode(Transform epicenter, float explosionForce, float explosionRadius)
    {
        foreach(Rigidbody explodebleObject in GetExplodableObjects(epicenter, explosionRadius))
            explodebleObject.AddExplosionForce(explosionForce, epicenter.transform.position, explosionRadius);
    }

    public void Explode(Specifications specifications, float explosionForce, float explosionRadius)
    {
        if(specifications.TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddExplosionForce(explosionForce, specifications.transform.position, explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Transform epicenter, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(epicenter.transform.position, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)  
            if(hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
