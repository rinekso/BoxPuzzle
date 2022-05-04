using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefabs, parentObject;

    [SerializeField]
    [Range(1,1000)]
    int length = 1;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Spawn()
    {
        int count = (int)(length / partDistance);

        for (int i = 0; i < count; i++)
        {
            GameObject tmp;

            tmp = Instantiate(partPrefabs, new Vector3(transform.position.x, transform.position.y + partDistance * (i+1), transform.position.z), Quaternion.identity, parentObject.transform);

            tmp.name = parentObject.transform.childCount.ToString();

            if(i == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if(snapFirst){
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }else{
                tmp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if(snapLast){
            parentObject.transform.Find((parentObject.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(reset){
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tmp);
            }
            reset = false;
        }
        if(spawn){
            Spawn();

            spawn = false;
        }
    }
}
