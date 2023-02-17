using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{    
    private Ability ability;
    
    [Space]
    [Header("Do not touch!")]    
    [SerializeField] Image icon;
    Action onPointer;
    
    public void Init(Ability ability)
    {
        this.ability = ability;
        icon.sprite = this.ability.icon;
        GetComponent<Button>().onClick.AddListener(
                ()=>AudioSource.PlayClipAtPoint(this.ability.sound, Camera.main.transform.position));
    }
    
    
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("over the button");
        var v = GetComponent<RectTransform>();
        Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
        Popup.instance.ShowPopup(position, ability.description);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Popup.instance.HidePopup();
        
        
    }
}
