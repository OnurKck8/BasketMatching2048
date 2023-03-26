using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<GameObject> PlaneObject = new List<GameObject>();
    public GameObject Particle_Confetti;



    public void OnCollisionEnter(Collision other)
    {

        PlaneObject.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision other)
    {
        if (PlaneObject.Contains(other.gameObject))
        {
            PlaneObject.Remove(other.gameObject);
        }
    }

}

