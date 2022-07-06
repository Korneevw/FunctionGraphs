using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal class FunctionSelector
    {
        public GroupBox GroupBox { get; set; }
        public ComboBox Selector { get; set; }
        public event Action? SelectedItemChanged;
        public FunctionSelector(Point location, Control.ControlCollection controls)
        {
            Selector = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(10, 20),
                Width = 200,  
            };
            Selector.Items.Add("Линейная функция");
            Selector.SelectedIndex = 0;
            Selector.SelectedValueChanged += (s, e) => SelectedItemChanged?.Invoke();

            GroupBox = new GroupBox()
            {
                Text = "Выбор функции",
                Size = new Size(244, 10 + Selector.Height + 10 + 10),
                Location = location
            };

            GroupBox.Controls.AddRange(new Control[] { Selector });
            controls.AddRange(new Control[] { GroupBox });
        }
    }
}
