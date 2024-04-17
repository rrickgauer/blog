namespace Blog.WpfGui.Helpers;


public interface IModelForm<T>
{
    public void EditModel(T model);
    public void NewModel();
}
