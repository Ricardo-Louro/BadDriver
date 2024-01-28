using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GunFlyToHand : MonoBehaviour
{
    [SerializeField] private XRGrabInteractableTwoAttach        pistolGrabInteractable;
    private GameObject                                          hand;

    private void SetHand(GameObject hand)
    {
        this.hand = hand;
    }

    /*
    private void Start()
    {
        pistolGrabInteractable.
    }
    */
}
