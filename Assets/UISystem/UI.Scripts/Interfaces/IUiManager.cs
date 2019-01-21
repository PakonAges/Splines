using System.Threading.Tasks;

public interface IUiManager
{
    Task InitViewsAsync();
    Task ShowWindowAsync<T>() where T : GenericView;
}
