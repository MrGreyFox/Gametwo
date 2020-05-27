using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class Inventory : MonoBehaviour
    {
        List<Item> list;
        public GameObject inventory;
        public GameObject container;
        public ThirdPersonUserControl controller;
        public Craft craft;
        public float rayDistance;

    // Start is called before the first frame update
    void Start()
        {
            list = new List<Item>();
            controller = GetComponent<ThirdPersonUserControl>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(transform.position, ray.direction * rayDistance);
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray, rayDistance);
            foreach (RaycastHit hit in hits)
            {
                    Item item = hit.collider.GetComponent<Item>();
                    if (item != null)
                    {
                        list.Add(item);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                if (inventory.activeSelf)
                {
                    craft.activate(false);
                    inventory.SetActive(false);
                    for (int i = 0; i < inventory.transform.childCount; i++)
                    {
                        if (inventory.transform.GetChild(i).transform.childCount > 0)
                        {
                            Destroy(inventory.transform.GetChild(i).transform.GetChild(0).gameObject);
                        }
                    }
                }
                else
                {
                    craft.activate(true);
                    inventory.SetActive(true);
                    int count = list.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Item it = list[i];
                        if (inventory.transform.childCount >= i)
                        {

                            GameObject img = Instantiate(container);
                            img.transform.SetParent(inventory.transform.GetChild(i).transform);
                            img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
                            img.GetComponent<Drag>().item = it;
                        }
                        else break;
                    }
                }
            }
        }
        void use(Drag drag)
        {
            if (drag.item.type == "potion red")
            {
                controller.addHealth(50);
                Destroy(drag.gameObject);
            }
            if(drag.item.type == "potion green")
            {
                controller.minusHealth(40);
                Destroy(drag.gameObject);
            }
            if (drag.item.type == "mushroom blue")
            {
                controller.addHealth(20);
                Destroy(drag.gameObject);
            }
            if (drag.item.type == "mushroom red")
            {
                controller.minusHealth(20);
                Destroy(drag.gameObject);
            }
            if (drag.item.type == "grass")
            {
                controller.addHealth(10);
                Destroy(drag.gameObject);
            }
            
            list.Remove(drag.item);
        }
        public void add(Item item)
        {
            if (list.FindIndex(x => x == item) == -1) list.Add(item);
        }
        public void removeItem(Item item)
        {
            list.Remove(item);
        }
        void remove(Drag drag)
        {
            Item it = drag.item;
            GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab));
            newo.transform.position = transform.position + transform.forward + transform.up;
            Destroy(drag.gameObject);
            list.Remove(it);
        }
    }

