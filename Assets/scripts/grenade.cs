using UnityEngine;

public class grenade : MonoBehaviour
{
    public GameObject grenadeprefab;
    public Transform grenadeSourceTransform;
    public float time = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(grenadeprefab, grenadeSourceTransform);
            if (time < Time.deltaTime)
            {
                Destroy(grenadeprefab);
            }
        }
    }
}
