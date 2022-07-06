namespace LinearFunctions
{
    public partial class MainForm : Form
    {
        private Camera _camera;
        private LinearFunction _linearFunction;
        private LinearFunctionInput _functionInput;
        private FunctionSelector _functionSelector;
        private CameraInput _cameraLocationInput;
        private MousePointDisplayerModeSelector _mousePointDisplayerModeSelector;

        private Point _mouseLocation;
        private Point? _dragMouseLocation;
        private PointF? _dragCameraLocation;

        private bool _ignoreAnyValueChanged = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            GridDisplayer.Display(_camera, e.Graphics);
            LinearFunctionDisplayer.Display(_camera, _linearFunction, e.Graphics);
            CoordinateDisplayer.Display(_camera, e.Graphics);
            if (_mousePointDisplayerModeSelector.X)
            {
                MousePointDisplayer.DisplayByX(_camera, _linearFunction, _mouseLocation.X, e.Graphics);
            }
            else if (_mousePointDisplayerModeSelector.Y)
            {
                MousePointDisplayer.DisplayByY(_camera, _linearFunction, _mouseLocation.Y, e.Graphics);
            }
            else if (_mousePointDisplayerModeSelector.XY)
            {
                MousePointDisplayer.Display(_camera, _linearFunction, _mouseLocation, e.Graphics);
            }
            e.Graphics.DrawLine(Pens.Black, new Point(_functionInput.GroupBox.Right + 10, 0), new Point(_functionInput.GroupBox.Right + 10, ClientSize.Height));
            base.OnPaint(e);
        }
        public MainForm()
        {
            InitializeComponent();
            _functionSelector = new FunctionSelector(new Point(10, 10), Controls);
            _functionInput = new LinearFunctionInput(new Point(10, _functionSelector.GroupBox.Bottom), Controls);
            _functionInput.AnyValueChanged += GraphInputValueChangedHandler;
            _camera = new Camera(1, new Size(ClientSize.Width, ClientSize.Height), new Point(_functionInput .GroupBox.Right + 10, 0));
            _linearFunction = new LinearFunction(_functionInput.K, _functionInput.B);
            _mousePointDisplayerModeSelector = new MousePointDisplayerModeSelector(new Point(10, _functionInput.GroupBox.Bottom), Controls);
            _cameraLocationInput = new CameraInput(new Point(10, _functionInput.BInput.Bottom), _camera, Controls);
            _cameraLocationInput.GroupBox.Location = new Point(10, _mousePointDisplayerModeSelector.GroupBox.Bottom);
            _cameraLocationInput.OnMove += () => this.Refresh();
            this.ClientSize = new Size(_camera.Location.X + _camera.Width, _camera.Height);
            this.MouseWheel += ResizeHandler;
            this.MouseUp += DragMovementUpHandler;
            this.MouseDown += DragMovementDownHandler;
            this.MouseMove += DragMovementMoveHandler;
            this.MouseMove += CursorPointDisplayerData;
            this.DoubleBuffered = true;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Графики функций";
        }

        private void CursorPointDisplayerData(object? sender, MouseEventArgs e)
        {
            _mouseLocation = e.Location;
            this.Refresh();
        }

        private void ResizeHandler(object? sender, MouseEventArgs e)
        {
            _camera.Scale += e.Delta / 120 * 0.1;
            if (_camera.Scale < 0.5) _camera.Scale = 0.5;
            this.Refresh();
        }
        private void DragMovementUpHandler(object? sender, MouseEventArgs e)
        {
            _dragMouseLocation = null;
            _dragCameraLocation = null;
        }
        private void DragMovementDownHandler(object? sender, MouseEventArgs e)
        {
            _dragMouseLocation = e.Location;
            _dragCameraLocation = _camera.GridLocation;
        }
        private void DragMovementMoveHandler(object? sender, MouseEventArgs e)
        {
            if (_dragMouseLocation.HasValue && _dragCameraLocation.HasValue)
            {
                _camera.GridLocation = new PointF(
                    _dragCameraLocation.Value.X + (float)((_dragMouseLocation.Value.X - e.Location.X) / (50 * _camera.Scale)),
                    _dragCameraLocation.Value.Y - (float)((_dragMouseLocation.Value.Y - e.Location.Y) / (50 * _camera.Scale)));
                this.Refresh();
            }
        }
        private void WindowResizeHandler(object? sender, EventArgs e)
        {
            _camera.Size = new Size(ClientSize.Width, ClientSize.Height);
            this.Refresh();
        }
        private void GraphInputValueChangedHandler()
        {
            if (_ignoreAnyValueChanged) return;
            _linearFunction.K = _functionInput.K;
            _linearFunction.B = _functionInput.B;
            this.Refresh();
        }
    }
}