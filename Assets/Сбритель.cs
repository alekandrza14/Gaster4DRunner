using UnityEngine;
using UnityEngine.UI;

public class Сбритель : MonoBehaviour
{
    public Text работыСделано;
    int e = 0;
    private void Update()
    {
        работыСделано.text = "работы Сделано : " + e;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Item(Clone)")
        {
            e++;
            FindObjectsByType<ItemSpawn>(sortmode.main)[Random.Range(0, FindObjectsByType<ItemSpawn>(sortmode.main).Length)].GetComponent<ItemSpawn>().Start();
            Destroy(other.gameObject);
        }
    }
}
