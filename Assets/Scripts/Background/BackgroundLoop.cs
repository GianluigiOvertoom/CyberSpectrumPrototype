using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] m_BackgroundObjects;
    public float m_Choke;

    private Camera m_MainCamera;
    private Vector2 m_ScreenBounds;
    private Vector3 m_LastScreenPosition;

    private void Start()
    {
        m_MainCamera = gameObject.GetComponent<Camera>();
        m_ScreenBounds = m_MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, m_MainCamera.transform.position.z));
        foreach(GameObject obj in m_BackgroundObjects)
        {
            loadChildObjects(obj);
        }
        m_LastScreenPosition = transform.position;
    }

    private void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - m_Choke;
        int childsNeeded = (int)Mathf.Ceil(m_ScreenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childsNeeded; i++){
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    private void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1){
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - m_Choke;
            if(transform.position.x + m_ScreenBounds.x > lastChild.transform.position.x + (halfObjectWidth / 8)){
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }else if(transform.position.x - m_ScreenBounds.x < firstChild.transform.position.x - (halfObjectWidth / 8)){
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    private void LateUpdate()
    {
        foreach(GameObject obj in m_BackgroundObjects)
        {
            repositionChildObjects(obj);
            float paralaxSpeed = Mathf.Clamp01(Mathf.Abs(transform.position.z / obj.transform.position.z));
            float difference = transform.position.x - m_LastScreenPosition.x;
            obj.transform.Translate(Vector3.right * difference * paralaxSpeed);
        }
        m_LastScreenPosition = transform.position;
    }
}
