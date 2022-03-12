using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SnailModdingTools
{
    public partial class SaveEditor : UserControl
    {
        public SaveEditor()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
