using System.Collections;
using UnityEngine;

public class Knight_InteractionEvent : MonoBehaviour
{
    public enum InteractionType { SIGN, DOOR, NPC}
    public InteractionType type;
    public Cat_UIFade fadeUI;
    
    public GameObject signPopup;
    public GameObject map;
    public GameObject house;

    [SerializeField] private Vector2 inHousePos;
    [SerializeField] private Vector2 outHousePos;

    private bool isInHouse;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }

    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            signPopup.SetActive(false);
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                signPopup.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRoutine(player));
                break;
            case InteractionType.NPC:
                signPopup.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        yield return StartCoroutine(fadeUI.Fade_Image(3f, Color.black ,true));;
        
       player.position = isInHouse ? outHousePos : inHousePos;
       
        map.SetActive(isInHouse);
        house.SetActive(!isInHouse);
        
        isInHouse = !isInHouse;
        
        yield return new WaitForSeconds(1f);
        
        yield return StartCoroutine(fadeUI.Fade_Image(3f, Color.black , false));;
        
    }

}
