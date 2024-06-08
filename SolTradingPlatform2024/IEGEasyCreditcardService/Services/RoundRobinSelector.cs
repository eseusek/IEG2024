namespace IEGEasyCreditcardService.Services
{
    public class RoundRobinSelector
    {
        private readonly List<ICreditcardValidator> _services;
        private int _currentIndex = -1;

        public RoundRobinSelector(List<ICreditcardValidator> services)
        {
            _services = services;
        }

        public ICreditcardValidator GetNextService()
        {
            _currentIndex = (_currentIndex + 1) % _services.Count;
            return _services[_currentIndex];
        }
    }


}
