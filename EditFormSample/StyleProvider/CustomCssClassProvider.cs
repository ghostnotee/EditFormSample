using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace EditFormSample.StyleProvider;

public class CustomCssClassProvider<TProviderType> : ComponentBase where TProviderType : FieldCssClassProvider, new()
{
    [CascadingParameter] private EditContext? CurrentEditContext { get; set; }

    public TProviderType Provider { get; set; } = new();

    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
            throw new InvalidOperationException(
                $"{nameof(CustomCssClassProvider<TProviderType>)} requires a cascading parameter of type {nameof(EditContext)}. For example, you can use {nameof(CustomCssClassProvider<TProviderType>)} inside an EditForm.");
        CurrentEditContext.SetFieldCssClassProvider(Provider);
    }
}