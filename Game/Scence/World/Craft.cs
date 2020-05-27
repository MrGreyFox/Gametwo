using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class Craft : MonoBehaviour
    {
        public Reciple[] reciples;
        public Transform items;
        public Transform result;
        public GameObject container;
        public Inventory inventory;

        [System.Serializable]
        public class Reciple
        {
            public GameObject item;
            public RecipleMaterial materials;
        }
        [System.Serializable]
        public class RecipleMaterial
        {
            public Vector3 A;
            public Vector3 B;
            public Vector3 C;
        }
        public void activate(bool isActive)
        {
            gameObject.SetActive(isActive);
            if (!isActive)
            {
                if (result.childCount > 0) Destroy(result.GetChild(0).gameObject);
                for (int i = 0; i < items.childCount; i++)
                {
                    if (items.GetChild(i).childCount > 0) Destroy(items.GetChild(i).GetChild(0).gameObject);
                }
            }
        }
        public void addInventory(Drag item)
        {
            for (int i = 0; i < items.childCount; i++)
            {
                if (items.GetChild(i).childCount > 0)
                {
                    GameObject g = items.GetChild(i).GetChild(0).gameObject;
                    inventory.removeItem(g.GetComponent<Drag>().item);
                    Destroy(g);
                }
            }
            inventory.add(item.item);
        }
        public void updateCraft()
        {
            if (result.childCount > 0) Destroy(result.GetChild(0).gameObject);
            List < int[] > list = new List<int[]>();
            int countRec = reciples.Length;
        for (int i = 0; i < countRec; i++)
        {
            int[] arr = new int[9] {
                 (int) reciples[i].materials.A.x,
                 (int) reciples[i].materials.A.y,
                 (int) reciples[i].materials.A.z,
                 (int) reciples[i].materials.B.x,
                 (int) reciples[i].materials.B.y,
                 (int) reciples[i].materials.B.z,
                 (int) reciples[i].materials.C.x,
                 (int) reciples[i].materials.C.y,
                 (int) reciples[i].materials.C.z,
                };
            list.Add(arr);
        }

            for (int i = 0; i < items.childCount; i++)
            {
                int id = 0;
                if (items.GetChild(i).childCount > 0) 
                id = items.GetChild(i).GetChild(0).GetComponent<Drag>().item.id;
                for (int j = 0; j < countRec; j++)
                {
                    if (list[j] == null) break;
                    if (list[j][i] != id) list[j] = null;
                }
            }

            for (int j = 0; j < countRec; j++)
            {
                if (list[j] != null)
                {
                    Reciple current = reciples[j];
                    Item item = current.item.GetComponent<Item>();
                    GameObject img = Instantiate(container);
                    img.transform.SetParent(result);
                    img.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.sprite);
                    img.GetComponent<Drag>().item = item;
                    break;
                }
            }
        }
    }
