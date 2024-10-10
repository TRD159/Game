using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenryController : MonoBehaviour
{
    private bool raccoonOnTrash = false;
    private int movementIndex = 0;
    public Vector3[] movementPoints;
    [SerializeField] float speed = 5f;
    [SerializeField] private HideOnCollide collisionOccur;

    private void Start()
    {
        collisionOccur.onRaccoonFirstTimeOnTrash += CollisionOccur_onRaccoonFirstTimeOnTrash;
    }

    private void CollisionOccur_onRaccoonFirstTimeOnTrash(object sender, System.EventArgs e)
    {
        raccoonOnTrash = true;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void Update()
    {
        if(raccoonOnTrash && movementIndex < movementPoints.Length)
        {
            HenryMovement();
        }
    }

    private void HenryMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, movementPoints[movementIndex], speed * Time.deltaTime);
        transform.LookAt(movementPoints[movementIndex]);

        if(transform.position == movementPoints[movementIndex])
        {
            movementIndex++;
        }
    }
}
