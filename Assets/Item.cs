using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static string itemObjGraped = "";
    public static float cooldown;
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<HyperbolicCamera>())
        {
          if(Input.GetKeyDown(KeyCode.E)) if (itemObjGraped == "")
            {
                itemObjGraped = name.Replace("(Clone)","");
                    cooldown = 0.5f;
                Destroy(gameObject);
            }
        }
    }
}
