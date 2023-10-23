using UnityEngine;

internal class settingsButton : GorillaPressableButton
{
    public override void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        gameObject.layer = 18;

        onPressButton = new UnityEngine.Events.UnityEvent();
        onPressButton.AddListener(new UnityEngine.Events.UnityAction(ButtonActivation));
    }

    public void ButtonActivation()
    {
        isOn = !isOn;
        buttonManager.currentPage = "settings";
    }
}