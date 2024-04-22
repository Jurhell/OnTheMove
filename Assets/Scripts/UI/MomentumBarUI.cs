using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MomentumBarUI : MonoBehaviour
{
    [SerializeField]
    private RawImage _mBarFG;

    [SerializeField]
    private MomentumBehavior _momentumBehavior;

    [SerializeField]
    private Gradient _gaugeBarGradient;

    [SerializeField]
    private TextMeshProUGUI _text;

    void Start()
    {
        Debug.Assert(_mBarFG);
        Debug.Assert(_momentumBehavior);
    }

    void Update()
    {
        if (_mBarFG == null || _momentumBehavior == null)
            return;

        float gauge = _momentumBehavior.Speed;

        //Min of 1 to ensure no dividing by zero or negative numbers
        float maxGauge = Mathf.Max(1, _momentumBehavior.MaxSpeed);

        //Get gauge as a value between 0 and 1
        float gaugePercentage = Mathf.Clamp01(gauge / maxGauge);

        //Set gauge bar scale
        Vector3 newScale = _mBarFG.rectTransform.localScale;
        newScale.x = gaugePercentage;
        _mBarFG.rectTransform.localScale = newScale;

        //Set gauge bar color
        _mBarFG.color = _gaugeBarGradient.Evaluate(gaugePercentage);
    }
}
