using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movimentação")]
    public float speed = 5f;
    public float arrivalThreshold = 0.1f;

    bool playerCanMove = true;
    Rigidbody2D rg;

    // destino definido pelo clique
    Vector2 targetPosition;
    bool hasTarget = false;

    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!playerCanMove) return;

        // Clique esquerdo: define destino
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = Vector3.zero;
            if (Camera.main != null)
                mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            targetPosition = new Vector2(mouseWorld.x, mouseWorld.y);
            hasTarget = true;
        }

        // Clique direito: cancela movimento
        if (Input.GetMouseButtonDown(1))
        {
            hasTarget = false;
            if (rg != null) rg.velocity = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if (!playerCanMove || !hasTarget) return;

        Vector2 current = rg != null ? rg.position : (Vector2)transform.position;
        float dist = Vector2.Distance(current, targetPosition);

        if (dist <= arrivalThreshold)
        {
            hasTarget = false;
            if (rg != null) rg.velocity = Vector2.zero;
            return;
        }

        Vector2 newPos = Vector2.MoveTowards(current, targetPosition, speed * Time.fixedDeltaTime);
        if (rg != null)
            rg.MovePosition(newPos);
        else
            transform.position = newPos;
    }

    void OnDrawGizmos()
    {
        if (hasTarget)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere((Vector3)targetPosition, 0.1f);
            Gizmos.DrawLine(transform.position, (Vector3)targetPosition);
        }
    }
}
