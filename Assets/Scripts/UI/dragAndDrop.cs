using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public towerScript tower;
    public GameObject rangeObject;
    public Transform rangeTransform;
    public gameManager manager;
    public float rangeScale = 2.8f;
    public float cameraCordinatZ = 1f;
    public bool isDraggable = true;

    private GameObject dragged;
    private GameObject range;

    private void Update()
    {
        if (manager.playerEnergy - tower.energy < 0)
        {
            isDraggable = false;
            GetComponent<Image>().color = Color.gray;
        }
        else
        {
            isDraggable = true;
            GetComponent<Image>().color = Color.white;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraCordinatZ);
            if(Camera.main != null)
            {
                dragged.transform.position = Camera.main.ScreenToWorldPoint(position);
                range.transform.position = Camera.main.ScreenToWorldPoint(position);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            dragged = Instantiate(gameObject, transform);
            range = Instantiate(rangeObject, rangeTransform);
            range.transform.localScale = new Vector3(tower.range / rangeScale, tower.range / rangeScale, 10f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            if (dragged != null)
            {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit && hit.collider.transform.tag == "empty")
                {
                    var position = hit.collider.gameObject.transform.position;
                    manager.playerEnergy -= tower.energy;
                    Instantiate(tower, position, Quaternion.identity);
                }

                Destroy(dragged);
                Destroy(range);
                dragged = null;
                range = null;
            }
        }
    }
    
}
