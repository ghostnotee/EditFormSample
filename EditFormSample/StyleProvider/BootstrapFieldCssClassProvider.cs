using Microsoft.AspNetCore.Components.Forms;

namespace EditFormSample.StyleProvider;

public class BootstrapFieldCssClassProvider : FieldCssClassProvider
{
    private readonly HashSet<string> _excludedFields = ["Gender"];
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        if (_excludedFields.Contains(fieldIdentifier.FieldName))
        {
            return "";
        }
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();
        var isModified = editContext.IsModified(fieldIdentifier);
        return (isModified, isValid) switch
        {
            (true, true) => "form-control modified is-valid",
            (true, false) => "form-control modified is-invalid",
            (false, true) => "form-control",
            (false, false) => "form-control"
        };
    }
}