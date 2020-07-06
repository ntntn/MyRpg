using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : Skill
{

    [SerializeField]
    public float rangeMultiplier;

    public float range;

    [SerializeField]
    GameObject fadeIn;
    [SerializeField]
    GameObject fadeOut;


    public override void Initialize(SkillController controller)
    {
        base.Initialize(controller);

        fadeIn.transform.position = user.transform.position;
        fadeIn.SetActive(true);

        user.transform.position += user.transform.forward * rangeMultiplier;

        controller.OnBlinkUsed.Invoke(rangeMultiplier);
        

        Invoke("InstantiateFadeOut", 0.3f);
        Invoke("HideFadeInFadeOut", 1f);
        Invoke("OnSkillCompleted", 2f);
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    void InstantiateFadeOut()
    {
        fadeOut.transform.position = user.transform.position;
        fadeOut.SetActive(true);
    }

    void HideFadeInFadeOut()
    {
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
