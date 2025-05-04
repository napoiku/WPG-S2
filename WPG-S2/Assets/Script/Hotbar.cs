using UnityEngine.UI;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    [SerializeField] private GameObject[] slot;

    public void rubahOutline(int pilih) {
        for (int i = 0; i < slot.Length; i++) // merubah warna ketika terpilih
        {
            Image image = slot[i].GetComponent<Image>();

            if (i == pilih)
            {
                image.color = Color.red;
            }
            else
            {
                image.color = Color.white;
            }
        }
    }
}