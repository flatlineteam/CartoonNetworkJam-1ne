using UnityEngine;
using System.Collections;

public class RacingGameController : MonoBehaviour {

    static public RacingGameController instance = null;

    [SerializeField]
    private CircleCollider2D topTarget = null;
    public CircleCollider2D TopTarget {
        get { return instance.topTarget; }
    }

    [SerializeField]
    private CircleCollider2D bottomTarget = null;
    public CircleCollider2D BottomTarget {
        get { return instance.bottomTarget; }
    }

    void Awake() {
        MakeInstance();
    }

    // Update is called once per frame
    void Update() {

    }

    public void MakeInstance() {
        if (instance == null)
            instance = this;
    }
}
