using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Vector2 mouseMovementScale = Vector2.one;
    public ObjectPool Pool;
    new Camera camera;

    private void Awake()
    {
        Pool = GetComponent<ObjectPool>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 mouse = new(Input.GetAxis("Mouse X") * mouseMovementScale.x, Input.GetAxis("Mouse Y") * mouseMovementScale.y);
        //transform.eulerAngles += new Vector3(-mouse.y, mouse.x, 0);

        if (Input.GetMouseButtonDown(0))
        {
            Ray screenRay = camera.ScreenPointToRay(Input.mousePosition);
            GameObject bullet = Pool.Pump();
            if(bullet is not null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.LookRotation(screenRay.direction);
                bullet.GetComponent<Bullet>().Activate();
            }
        }

    }
}
