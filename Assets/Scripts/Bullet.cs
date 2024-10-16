using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    public void Activate()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IGetHit Hit)) Hit.GetHit();
        gameObject.SetActive(false);
    }
}

public interface IGetHit
{
    public abstract void GetHit();
}