namespace LinearFunctions
{
    internal class LinearFunctionInput
    {
        public double K { get { return (double)KInput.Value; } }
        public double B { get { return (double)BInput.Value; } }
        public GroupBox GroupBox { get; set; }
        public Label FormulaLeft { get; set; }
        public Label FormulaK { get; set; }
        public Label FormulaMid { get; set; }
        public Label FormulaB { get; set; }
        public NumericUpDown KInput { get; set; }
        public NumericUpDown BInput { get; set; }
        public event Action? AnyValueChanged;
        public LinearFunctionInput(Point location, Control.ControlCollection controls)
        {
            GroupBox = new GroupBox()
            {
                Location = location,
                Text = "Текущая функция"
            };

            FormulaLeft = new Label()
            {
                Location = new Point(10, 20),
                Font = new Font(Form.DefaultFont.FontFamily, 18),
                Text = "y(x) =",
            };
            FormulaLeft.AutoSize = true;
            FormulaLeft.Size = FormulaLeft.PreferredSize;

            KInput = new NumericUpDown()
            {
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = 0.1M,
                Location = new Point(FormulaLeft.Right, FormulaLeft.Top + 9)
            };
            KInput.ValueChanged += (s, e) => AnyValueChanged?.Invoke();
            KInput.Width = 50;

            FormulaK = new Label()
            {
                Location = new Point(KInput.Left + KInput.Width / 2 - 12, KInput.Bottom),
                Font = new Font(Form.DefaultFont.FontFamily, 18),
                Text = "k",
            };
            FormulaK.AutoSize = true;
            FormulaK.Size = FormulaK.PreferredSize;

            FormulaMid = new Label()
            {
                Location = new Point(KInput.Right, FormulaLeft.Top),
                Font = new Font(Form.DefaultFont.FontFamily, 18),
                Text = "x +"
            };
            FormulaMid.AutoSize = true;
            FormulaMid.Width = 50;

            BInput = new NumericUpDown()
            {
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = 0.1M,
                Location = new Point(FormulaMid.Right, FormulaLeft.Top + 9),
            };
            BInput.ValueChanged += (s, e) => AnyValueChanged?.Invoke();
            BInput.Width = 50;

            FormulaB = new Label()
            {
                Location = new Point(BInput.Left + BInput.Width / 2 - 12, BInput.Bottom),
                Font = new Font(Form.DefaultFont.FontFamily, 18),
                Text = "b",
            };
            FormulaB.AutoSize = true;
            FormulaB.Size = FormulaB.PreferredSize;

            GroupBox.Width = 10 + FormulaLeft.Width + KInput.Width + FormulaMid.Width + BInput.Width + 10;
            GroupBox.Controls.AddRange(new Control[] { FormulaLeft, KInput, FormulaK, FormulaMid, BInput, FormulaB });
            controls.Add(GroupBox);
        }
    }
}