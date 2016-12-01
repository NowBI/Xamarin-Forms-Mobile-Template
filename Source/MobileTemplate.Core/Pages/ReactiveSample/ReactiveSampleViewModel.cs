using System;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Reactive.Bindings;

namespace MobileTemplate.Core.Pages.ReactiveSample
{
    public class ReactiveSampleViewModel : IDisposable
    {
        public IReactiveProperty<string> TextInput { get; }

        public IReadOnlyReactiveProperty<char?> FirstCharacter { get; }
        public IReadOnlyReactiveProperty<string> FirstCharacterLabel { get; }

        public IReadOnlyReactiveProperty<int> StringLength { get; }
        public IReadOnlyReactiveProperty<string> StringLengthLabel { get; }

        public IReadOnlyReactiveProperty<TimeSpan> TimeOnPage { get; }
        public IReadOnlyReactiveProperty<string> TimeOnPageLabel { get; }

        public ReactiveSampleViewModel()
        {
            TextInput = new ReactiveProperty<string>("");
            FirstCharacter = TextInput.Select(x => x.ToCharArray()).Select(x => x.Any() ? (char?)x.First() : null).ToReadOnlyReactiveProperty();
            FirstCharacterLabel = FirstCharacter.Select(x => x != null ? $"The first character is {x.ToString()}" : "There is no first character!").ToReadOnlyReactiveProperty();
            StringLength = TextInput.Select(x => x.Length).ToReadOnlyReactiveProperty();
            StringLengthLabel = StringLength.Select(x => $"The string is {x} character{(x != 1 ? "s" : "")} long.").ToReadOnlyReactiveProperty();

            var timePageLoaded = DateTime.Now;
            TimeOnPage = Observable.Interval(TimeSpan.FromSeconds(1)).Select(x => DateTime.Now.Subtract(timePageLoaded)).ToReadOnlyReactiveProperty();
            TimeOnPageLabel = TimeOnPage.Select(x => (int)x.TotalSeconds).Select(x => $"You've been on this page for {x} second{(x != 1 ? "s" : "")}.").ToReadOnlyReactiveProperty();
        }

        public void Dispose()
        {
            TextInput?.Dispose();
            FirstCharacter?.Dispose();
            StringLength?.Dispose();
            StringLengthLabel?.Dispose();
            FirstCharacterLabel?.Dispose();

            TimeOnPage?.Dispose();
            TimeOnPageLabel?.Dispose();
        }
    }
}
