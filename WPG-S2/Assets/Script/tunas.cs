using UnityEngine;

public class tunas : MonoBehaviour
{
    public int[] biji = new int[4] { 2, 2, 2, 2 };
    public int total = 1;

    void Update() {
    total = biji[0] + biji[1] + biji[2] + biji[3];
}
    public bool KurangiBiji(int index)
    {
        if (index >= 0 && index < biji.Length && biji[index] > 0)
        {
            biji[index]--;
            Debug.Log($"Biji di slot {index} dikurangi. Sisa: {biji[index]}");
            return true;
        }
        return false;
    }

    public int CekBiji(int index)
    {
        if (index >= 0 && index < biji.Length)
        {
            return biji[index];
        }
        return 0;
    }
}