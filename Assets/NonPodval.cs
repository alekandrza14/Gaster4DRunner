using UnityEngine;

public class NonPodval : MonoBehaviour
{
    public Camera player;
    void Start()
    {
        player = Camera.main;
        if (PolitDate.IsGoodF(politicfreedom.avtoritatian)) player.backgroundColor = Color.white;
        if (PolitDate.IsGoodF(politicfreedom.lidertatian)) player.backgroundColor = Color.black;
    }
}
