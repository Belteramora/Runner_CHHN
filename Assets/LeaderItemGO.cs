using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderItemGO : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI number;

    [SerializeField]
    private TextMeshProUGUI score;

    [SerializeField]
    private TextMeshProUGUI time;

    public void Setup(string num, string score, string time)
    {
        number.text = num;
        this.score.text = score;
        this.time.text = time;
    }
}
