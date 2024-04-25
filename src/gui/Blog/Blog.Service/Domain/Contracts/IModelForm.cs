namespace Blog.Service.Domain.Contracts;


public class NewModelFormArgs
{
    public required string Title { get; set; }

    public string SaveButtonText { get; set; } = "Save";
    public string CancelButtonText { get; set; } = "Cancel";

    public required Guid MessengerToken { get; set; }
}

public class EditModelFormArgs<T> : NewModelFormArgs
{
    public required T Model { get; set; }
}


public interface IModelForm<T>
{
    public void EditModel(EditModelFormArgs<T> args);
    public void NewModel(NewModelFormArgs args);
}