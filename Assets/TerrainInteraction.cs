using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainInteraction : MonoBehaviour
{

    public GameObject castleGate;
    private float castleGateHeight = 6.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || castleGate.transform.position.y < castleGateHeight)
        {
            Vector3 newPos = new Vector3(castleGate.transform.position.x, castleGateHeight, castleGate.transform.position.z);
            castleGate.transform.position = Vector3.Lerp(castleGate.transform.position, newPos, Time.deltaTime * 0.1f);
        }
    }
}
