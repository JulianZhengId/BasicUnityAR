using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

public class ClickHandler : MonoBehaviour
{
    public IObservable<EventArgs> clickTrigger;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        if (gameObject.GetComponent<ObservablePointerClickTrigger>() == null)
        {
            clickTrigger = gameObject.AddComponent<ObservablePointerClickTrigger>()
                .OnPointerClickAsObservable()
                .Select(e => EventArgs.Empty);
        }
        else
        {
            clickTrigger = gameObject.GetComponent<ObservablePointerClickTrigger>()
                .OnPointerClickAsObservable()
                .Select(e => EventArgs.Empty);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        clickTrigger.Subscribe(clickOutput).AddTo(this);
    }

    public void clickOutput(EventArgs e)
    {
        ApplyOutline();
    }

    public void UndoOutline()
    {
        myRenderer.material.SetFloat("_OutlineWidth", 1);
    }

    public void ApplyOutline()
    {
        myRenderer.material.SetFloat("_OutlineWidth", 1.0225f);
        myRenderer.material.SetColor("_OutlineColor", new Color(1f, 0.64f, 0f));
    }
}
