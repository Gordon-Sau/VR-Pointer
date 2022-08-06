using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefManager : MonoBehaviour
{
    static RefManager instance;
    public MakeLine lineMaker;
    public OnClick onClickController;
    void Awake() { 
        instance = this;
    }

    static public MakeLine getLineMaker() {
        return instance.lineMaker;
    }

    static public OnClick getOnClickController() {
        return instance.onClickController;
    }

}
