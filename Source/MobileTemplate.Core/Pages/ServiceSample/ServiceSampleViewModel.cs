using System;
using System.Reactive.Linq;
using MobileTemplate.Core.Services;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.ServiceSample
{
    public class ServiceSampleViewModel : IDisposable
    {
        private readonly ISampleService _sampleService;

        public IReadOnlyReactiveProperty<string> CommonServiceText { get; }
        public ReactiveCommand CommonServiceCommand { get; }
        private IDisposable _commonCommandSubscription;

        public IReadOnlyReactiveProperty<string> PlatformServiceText { get; }
        public ReactiveCommand PlatformServiceCommand { get; }
        private IDisposable _platformCommandSubscription;

        public ServiceSampleViewModel(ISampleService sampleService)
        {
            _sampleService = sampleService;

            CommonServiceText = new ReactiveProperty<string>(_sampleService.CommonText);
            CommonServiceCommand = new ReactiveCommand();
            _commonCommandSubscription = CommonServiceCommand.Subscribe(ExecuteCommonCommand);

            PlatformServiceText = new ReactiveProperty<string>(_sampleService.PlatformText);
            PlatformServiceCommand = new ReactiveCommand();
            _platformCommandSubscription = PlatformServiceCommand.Subscribe(ExecutePlatformCommand);
        }

        private void ExecuteCommonCommand(object parameter)
        {
            _sampleService.CommonCommand();
        }

        private void ExecutePlatformCommand(object parameter)
        {
            _sampleService.PlatformCommand();
        }

        public void Dispose()
        {
            CommonServiceText?.Dispose();
            CommonServiceCommand?.Dispose();
            _commonCommandSubscription?.Dispose();

            PlatformServiceText?.Dispose();
            PlatformServiceCommand?.Dispose();
            _platformCommandSubscription?.Dispose();
        }
    }
}
