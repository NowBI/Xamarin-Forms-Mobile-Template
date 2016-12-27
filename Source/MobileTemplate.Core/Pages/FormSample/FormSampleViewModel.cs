using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using MobileTemplate.Core.Services;
using Reactive.Bindings;
using Xamarin.Forms;

namespace MobileTemplate.Core.Pages.FormSample
{
    public class FormSampleViewModel : IDisposable
    {
        public IDictionary<string, Color> PickerItems { get; }
        public IReadOnlyReactiveProperty<string> PickedText { get; }
        public IReadOnlyReactiveProperty<Color> PickedColor { get; }

        public IReactiveProperty<string> EntryInput { get; }
        public IReactiveProperty<double> SliderInput { get; }
        public IReactiveProperty<bool> SwitchInput { get; }
        public IReactiveProperty<int> PickerInput { get; }
        public IReactiveProperty<DateTime> DatePickerInput { get; }
        public IReactiveProperty<TimeSpan> TimePickerInput { get; }
        public IReactiveProperty<double> StepperInput { get; }
        public ReactiveCommand SubmitCommand { get; }

        private readonly IDisposable _submitDisposable;

        private readonly INavigationService _navigationService;

        public FormSampleViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            EntryInput = new ReactiveProperty<string>();
            SliderInput = new ReactiveProperty<double>();
            SwitchInput = new ReactiveProperty<bool>();
            PickerInput = new ReactiveProperty<int>();

            var now = DateTime.Now;
            DatePickerInput = new ReactiveProperty<DateTime>(now);
            TimePickerInput = new ReactiveProperty<TimeSpan>(now.TimeOfDay);
            StepperInput = new ReactiveProperty<double>();
            SubmitCommand = new ReactiveCommand();

            PickerItems = new Dictionary<string, Color>
            {
                {"None", Color.Transparent },
                { "Red", Color.Red },
                { "Green", Color.Green },
                { "Yellow", Color.Yellow },
                { "Aqua", Color.Aqua },
                { "Olive", Color.Olive },
                { "Pink", Color.Pink },
            };

            var pickedItem = PickerInput.Select(index => PickerItems.ElementAt(index));
            PickedText = pickedItem.Select(x => x.Key).ToReadOnlyReactiveProperty();
            PickedColor = pickedItem.Select(x=>x.Value).ToReadOnlyReactiveProperty();

            _submitDisposable = SubmitCommand.Subscribe(Submit);
        }

        private void Submit(object input)
        {
            var text = CreateText();
            _navigationService.Push(new ContentPage
            {
                Title = "Submitted Details",
                Content = new Label
                {
                    Text = text,
                    BackgroundColor = PickedColor.Value
                }
            });
        }

        private string CreateText()
        {
            var sb = new StringBuilder();
            sb.Append($"Entry: {EntryInput.Value}\n");
            sb.Append($"Slider: {SliderInput.Value}\n");
            sb.Append($"Picker: {PickedText.Value}\n");
            sb.Append($"Switch Enabled: {SwitchInput.Value}\n");
            sb.Append($"Date: {DatePickerInput.Value.ToString("D")}\n");
            sb.Append($"Time: {TimePickerInput.Value}\n");
            sb.Append($"Stepper: {StepperInput.Value}\n");
            return sb.ToString();
        }

        public void Dispose()
        {
            PickedColor?.Dispose();
            EntryInput?.Dispose();
            SliderInput?.Dispose();
            SwitchInput?.Dispose();
            DatePickerInput?.Dispose();
            TimePickerInput?.Dispose();
            StepperInput?.Dispose();
            SubmitCommand?.Dispose();
            _submitDisposable?.Dispose();
        }
    }
}
