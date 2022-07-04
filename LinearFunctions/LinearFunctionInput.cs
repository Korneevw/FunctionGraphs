namespace LinearFunctions
{
    internal class LinearFunctionInput
    {
        public double K { get { return (double)KInput.Value; } }
        public double B { get { return (double)BInput.Value; } }
        public Label KInputLabel { get; set; }
        public NumericUpDown KInput { get; set; }
        public Label BInputLabel { get; set; }
        public NumericUpDown BInput { get; set; }
        public event Action? AnyValueChanged;
        public LinearFunctionInput(Point location, Control.ControlCollection controls)
        {
            KInputLabel = new Label()
            {
                Text = "Значение k:",
                Font = new Font(Form.DefaultFont.FontFamily, 12),
                Location = location
            };
            KInputLabel.Size = KInputLabel.PreferredSize;

            KInput = new NumericUpDown()
            {
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = 0.1M,
                Location = new Point(KInputLabel.Right, location.Y)
            };
            KInput.ValueChanged += (s, e) => AnyValueChanged?.Invoke();

            BInputLabel = new Label()
            {
                Text = "Значение b:",
                Font = new Font(Form.DefaultFont.FontFamily, 12),
                Location = new Point(location.X, KInput.Bottom + 10)
            };
            BInputLabel.Size = BInputLabel.PreferredSize;

            BInput = new NumericUpDown()
            {
                DecimalPlaces = 2,
                Minimum = decimal.MinValue,
                Maximum = decimal.MaxValue,
                Increment = 0.1M,
                Location = new Point(BInputLabel.Right, KInput.Bottom + 10),
            };
            BInput.ValueChanged += (s, e) => AnyValueChanged?.Invoke();
            controls.AddRange(new Control[] { KInputLabel, KInput, BInputLabel, BInput });
        }
    }
}