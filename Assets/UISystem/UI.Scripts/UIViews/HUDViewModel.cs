using Zenject;

public class HUDViewModel
{
    public HUDView _HUDView { get; set; }

    //public HUDViewModel(HUDView hUDView)
    //{
    //    _HUDView = hUDView;
    //}

    public void UpdateData(int data)
    {
        _HUDView.DataText = data.ToString();
    }
}