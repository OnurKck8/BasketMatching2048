using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

    public class MatchMaker : MonoBehaviour
    {
        public List<GameObject> PlacedObject = new List<GameObject>();
        public GameObject PointA;
        float timer = 0.8f;
        GameManager gameManager;


        void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
          
            if (PlacedObject.Count == 0)
            {
                PlacedObject.Add(other.gameObject);
                gameManager.hand.SetActive(false);

            }
            else if (other.gameObject.transform.name.Contains(PlacedObject[0].name) == true || PlacedObject[0].gameObject.transform.name.Contains(other.name) == true )
            {
            
                other.transform.DOMove(PointA.transform.position, timer);
                PlacedObject[0].gameObject.transform.DOMove(PointA.transform.position, timer);
                PlacedObject.Clear();
                gameManager.hand.SetActive(false);

            }
            else
            {
                gameManager.wrong_sound.Play();
                other.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1), 1, Random.Range(2, 3)) * 120 * Time.deltaTime;
                PlacedObject[0].gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1), 1, Random.Range(2, 3)) * 120 * Time.deltaTime;
            }
        }
        private void OnTriggerExit(Collider other)
        {
           PlacedObject.Clear();

           if (PlacedObject.Contains(other.gameObject))
           {
                PlacedObject.Remove(other.gameObject);
            
           }
        }

    }

