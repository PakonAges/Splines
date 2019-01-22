using System.Threading.Tasks;

namespace myUi
{
    public interface IUiManager
    {
        Task InitViewsAsync();
        Task ShowWindowAsync<T>() where T : GenericView;
        void UpdateViews(float iDeltaTime);
        void CloseWindow(GenericView window);
    }
}
