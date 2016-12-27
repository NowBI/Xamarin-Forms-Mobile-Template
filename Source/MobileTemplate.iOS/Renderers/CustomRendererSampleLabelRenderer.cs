using MobileTemplate.Core.Controls;
using MobileTemplate.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomRendererSampleLabel), typeof(CustomRendererSampleLabelRenderer))]
namespace MobileTemplate.iOS.Renderers
{
    public class CustomRendererSampleLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null && e.OldElement == null) // Indicates that the item has been created.
            {
                // Construction Logic
                NativeView.Alpha = 0.5f;
                NativeView.BackgroundColor = Color.Pink.ToUIColor();
                NativeView.AccessibilityLabel = "This is the screen reader text. You didn't forget about the visually impaired, I trust?";
            }else if (e.NewElement == null && e.OldElement != null) // Indicates that the item has been destroyed.
            {
                // Deconstruction Logic
            }
        }
    }
}