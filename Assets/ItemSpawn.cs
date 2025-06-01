using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject Item;
    public HyperbolicPoint pos;
   public void Start()
    {
        Hyperbolic2D hyperbolicPoint = pos.HyperboilcPoistion.copy();
        HyperbolicPoint obj = Instantiate(Item, Vector3.zero, Quaternion.identity).GetComponent<HyperbolicPoint>();
        obj.HyperboilcPoistion = hyperbolicPoint;
    }
}
