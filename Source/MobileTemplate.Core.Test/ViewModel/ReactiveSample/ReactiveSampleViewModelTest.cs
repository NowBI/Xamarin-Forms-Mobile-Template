using MobileTemplate.Core.Pages.ReactiveSample;
using Xunit;

namespace MobileTemplate.Core.Test.ViewModel.ReactiveSample
{
    public class ReactiveSampleViewModelTest
    {
        private readonly ReactiveSampleViewModel _vm;

        public ReactiveSampleViewModelTest()
        {
            _vm = new ReactiveSampleViewModel();
        }

        [Fact]
        public void FirstCharacter_ShouldReflectFirstCharacterOfTextInput()
        {
            Assert.NotEqual('f',_vm.FirstCharacter.Value);
            _vm.TextInput.Value = "fabulous";
            Assert.Equal('f', _vm.FirstCharacter.Value);
            _vm.TextInput.Value = "bessy";
            Assert.Equal('b', _vm.FirstCharacter.Value);
            _vm.TextInput.Value = "";
            Assert.Equal(null, _vm.FirstCharacter.Value);
        }

        [Fact]
        public void StringLength_ShouldReflectLengthOfTextInput()
        {
            Assert.Equal(0, _vm.StringLength.Value);
            _vm.TextInput.Value = "fabulous";
            Assert.Equal(8, _vm.StringLength.Value);
            _vm.TextInput.Value = "bessy";
            Assert.Equal(5, _vm.StringLength.Value);
            _vm.TextInput.Value = "";
            Assert.Equal(0, _vm.StringLength.Value);
        }
    }
}
