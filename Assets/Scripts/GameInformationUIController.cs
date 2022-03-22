using UnityEngine;
using UnityEngine.UI;

public class GameInformationUIController : MonoBehaviour {
    private Text text; 

    public void Start() {
        text = GetComponent<Text>();
        text.text = $"{Application.productName} {Application.version}";
    }
}
