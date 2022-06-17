using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBind : MonoBehaviour
{
    public KeyCode keyTower;
    
    private GameObject dragged;
    public towerScript tower;
    public gameManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyTower))
            keyBind();
    }
    
    private void keyBind()
    {
        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        dragged = Instantiate(gameObject, transform);
        if (Camera.main != null)
            dragged.transform.position = Camera.main.ScreenToWorldPoint(position);
        if (dragged != null)
        {
            var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && hit.collider.transform.tag == "empty")
            {
                manager.playerEnergy -= tower.energy;
                Instantiate(tower, hit.collider.gameObject.transform.position, Quaternion.identity);
            }

            Destroy(dragged);
            dragged = null;
        }
    }
}
