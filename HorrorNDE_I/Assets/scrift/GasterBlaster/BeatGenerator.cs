using UnityEngine;
using System.Text;
using System.Collections.Generic;

public class BeatGenerator : MonoBehaviour
{
    [Header("Cấu hình beat")]
    public float bpm = 72f;
    public float songStartTime = 2f;   // Bắt đầu từ giây thứ 2
    public float songDuration = 319f;  // Tổng thời lượng bài hát (5 phút 19 giây)

    void Start()
    {
        float beatInterval = 60f / bpm;
        List<float> beatList = new List<float>();

        for (float t = songStartTime; t <= songDuration; t += beatInterval)
        {
            beatList.Add((float)System.Math.Round(t, 3)); // làm tròn 3 chữ số
        }

        // In ra dạng mảng C#
        StringBuilder sb = new StringBuilder("public float[] beatTimes = new float[] {\n    ");
        for (int i = 0; i < beatList.Count; i++)
        {
            sb.Append(beatList[i].ToString("F3")).Append("f");
            if (i < beatList.Count - 1)
                sb.Append(", ");
            if ((i + 1) % 8 == 0)
                sb.Append("\n    ");
        }
        sb.Append("\n};");

        Debug.Log(sb.ToString());
    }
}
