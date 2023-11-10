using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        var offset = CreateLayerOffset(collider);
        if (offset == Vector3.zero)
            return;
        transform.position += offset;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var offset = CreateLayerOffset(collider);
        if (offset == Vector3.zero)
            return;
        transform.position -= offset;
    }

    private Vector3 CreateLayerOffset(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Transform transform = collider.transform;
            float Z = transform.localPosition.z;
            return new Vector3(0, 0, Z - 1);
        }
        
        return Vector3.zero;
    }
}
