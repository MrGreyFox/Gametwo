using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public Transform canvas;
        public Transform old;
        private GameObject player;
        public Item item;
        Craft craft;
        // Start is called before the first frame update
        void Start()
        {
            canvas = GameObject.Find("Canvas").transform;
            player = GameObject.FindGameObjectWithTag("Player");
            craft = GameObject.Find("Craft").GetComponent<Craft>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            old = transform.parent;
            transform.SetParent(canvas);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            if (old.name == "ResultItem") craft.addInventory(this);
            else if (old.name == "CraftItem") craft.updateCraft();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            if (transform.parent == canvas)
            {
                transform.SetParent(old);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (transform.parent.name == "ResultItem" || transform.parent.name == "CraftItem") return;
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                player.BroadcastMessage("use", this);
            }
            else player.BroadcastMessage("remove", this);
        }
    }
