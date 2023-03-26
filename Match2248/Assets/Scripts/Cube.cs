using System.Collections;
using UnityEngine;


    public class Cube : MonoBehaviour
    {
        public int value;

        public GameObject nextCube;
        public Rigidbody rb;

        GameObject pointmiddle;

        public int ID;

        GameManager gameManager;

        private void Awake()
        {
            ID = GetInstanceID();
            rb = gameObject.GetComponent<Rigidbody>();
            pointmiddle = GameObject.Find("PointMiddle");
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        private void Update()
        {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.15f, 1.15f), transform.position.y, transform.position.z);

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Finish")
            {
                gameObject.tag = "Cube";

            }


            if (collision.gameObject.CompareTag("Cube"))
            {
                if (collision.gameObject.TryGetComponent(out Cube cube))
                {
                    if (cube.value == value)
                    {
                        if (ID < cube.ID) return;
                        Destroy(cube.gameObject);
                        Destroy(this.gameObject);
                        if (nextCube)
                        {
                            gameManager.merge_sound.Play();
                            gameManager.Score += Random.Range(1, 5);

                            GameObject temp = Instantiate(nextCube, pointmiddle.transform.position, Quaternion.identity);
                            temp.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1), 1, Random.Range(2, 3)) * 120 * Time.deltaTime;
                            temp.GetComponent<ParticleSystem>().startSize = 1.5f;

                            gameManager.currentTime += Random.Range(3, 7);
                            gameManager.timetext.text = gameManager.currentTime.ToString();
                            int randomIndex = Random.Range(0, gameManager.cubes.Length);
                            Instantiate(gameManager.cubes[randomIndex], gameManager.spawnPoint.transform.position + new Vector3(0 + Random.Range(-1.25f, 1.25f), 0, 0 + Random.Range(-0.2f, 2)), Quaternion.identity);

                        }
                    }

                }
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Finish")
            {
                gameObject.tag = "Untagged";
                StartCoroutine(wait());

            }
        }
        IEnumerator wait()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<ParticleSystem>().startSize = 0;
        }

    }


