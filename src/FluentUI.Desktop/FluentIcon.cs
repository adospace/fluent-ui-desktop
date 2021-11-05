using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace FluentUI.Desktop
{
    public class FluentIcon : FrameworkElement
    {
        static FluentIcon()
        {
        }

        private static readonly Typeface _typeface = new Typeface(new FontFamily(new Uri("pack://application:,,,/FluentUI.Desktop;component/Fonts/Segoe Fluent Icons.ttf"), "./#Segoe Fluent Icons"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);


        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(FluentIconKey), typeof(FluentIcon), new FrameworkPropertyMetadata(FluentIconKey.None, FrameworkPropertyMetadataOptions.AffectsRender));

        public FluentIconKey Icon
        {
            get { return (FluentIconKey)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public double Size
        {
            get { return TextElement.GetFontSize(this); }
            set { TextElement.SetFontSize(this, value); }
        }

        //public static readonly DependencyProperty SizeProperty =
        //    DependencyProperty.Register("Size", typeof(double), typeof(FabricIcon), new FrameworkPropertyMetadata(14.0, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));

        public Brush Foreground
        {
            get { return TextElement.GetForeground(this); }
            set { TextElement.SetForeground(this, value); }
        }

        //public static readonly DependencyProperty ForegroundProperty =
        //    DependencyProperty.Register("Foreground", typeof(Brush), typeof(FabricIcon), new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(Math.Min(availableSize.Width, Size), Math.Min(availableSize.Height, Size));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (Icon != FluentIconKey.None)
            {
                var ft = new FormattedText(
                    char.ConvertFromUtf32((int)Icon),
                    CultureInfo.InvariantCulture,
                    FlowDirection.LeftToRight,
                    _typeface,
                    Size,
                    Foreground,
                    null,
                    TextFormattingMode.Ideal,
                    VisualTreeHelper.GetDpi(this).PixelsPerDip)
                    ;

                drawingContext.DrawText(ft, new Point());
            }

            base.OnRender(drawingContext);
        }
    }

}
