namespace Burikaigi.Client.Services
{
    public class LoadingService
    {
        bool _loading = false;

        public bool Loading
        {
            get => _loading;
            set
            {
                _loading = value;
                OnLoadingChanged?.Invoke(this, value);
            }
        }

        public event EventHandler<bool>? OnLoadingChanged;
    }
}
