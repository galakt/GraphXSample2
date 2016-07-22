using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GraphX.Controls;

namespace GraphXSample2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ZoomControl _zoomCtrl;
        private SampleGraphArea _graph;

        public ZoomControl ZoomCtrl
        {
            get { return _zoomCtrl; }
            set { _zoomCtrl = value; }
        }
        public SampleGraphArea Graph
        {
            get { return _graph; }
            set { _graph = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            this.Loaded += MainWindow_OnLoaded;

            Graph = new SampleGraphArea();
            ZoomCtrl = new ZoomControl
            {
                Background = new SolidColorBrush(Colors.LightGray),
                Foreground = new SolidColorBrush(Colors.Black),
                ZoomSensitivity = 10d,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Content = Graph
            };
            ZoomCtrl.AllowDrop = true;
        }


        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            GenerateGraph();
        }

        private void GenerateGraph()
        {
            // create core
            var logicCore = new SampleLogicCore();

            // create vertex
            var q1 = new SampleDataVertex("Sample name 1") { ImageId = 1, Name = "Sample text" };
            var q2 = new SampleDataVertex("Sample name 2") { ImageId = 2, Name = "Sample text" };
            var q3 = new SampleDataVertex("Sample name 1") { ImageId = 1, Name = "Sample text" };
            var q4 = new SampleDataVertex("Sample name 1")
            {
                ImageId = 1,
                Name = "Проверить включение в работу автоматических систем"
            };
            var q5 = new SampleDataVertex("Sample name 2") { ImageId = 2, Name = "Sample text" };
            var q6 = new SampleDataVertex("Sample name 1") { ImageId = 1, Name = "Sample text" };
            var q7 = new SampleDataVertex("Sample name 1") { ImageId = 1, Name = "Sample text" };

            // add vertex
            logicCore.Graph.AddVertex(q1);
            logicCore.Graph.AddVertex(q2);
            logicCore.Graph.AddVertex(q3);
            logicCore.Graph.AddVertex(q4);
            logicCore.Graph.AddVertex(q5);
            //logicCore.Graph.AddVertex(q6);
            //logicCore.Graph.AddVertex(q7);

            // create edges
            logicCore.Graph.AddEdge(new SampleDataEdge
            {
                ID = 1,
                Source = q1,
                SourceConnectionPointId = 5,
                Target = q2,
                TargetConnectionPointId = 1
            });
            logicCore.Graph.AddEdge(new SampleDataEdge
            {
                ID = 2,
                Source = q2,
                SourceConnectionPointId = 3,
                Target = q3,
                TargetConnectionPointId = 1,
                Text = "text",
                ToolTipText = "tooltiptext"
            });
            logicCore.Graph.AddEdge(new SampleDataEdge
            {
                ID = 3,
                Source = q2,
                SourceConnectionPointId = 4,
                Target = q4,
                TargetConnectionPointId = 1
            });
            logicCore.Graph.AddEdge(new SampleDataEdge
            {
                ID = 4,
                Source = q3,
                SourceConnectionPointId = 5,
                Target = q4,
                TargetConnectionPointId = 1
            });
            logicCore.Graph.AddEdge(new SampleDataEdge
            {
                ID = 5,
                Source = q4,
                SourceConnectionPointId = 5,
                Target = q5,
                TargetConnectionPointId = 1
            });
            //logicCore.Graph.AddEdge(new SampleDataEdge
            //{
            //    ID = 6,
            //    Source = q5,
            //    SourceConnectionPointId = 3,
            //    Target = q6,
            //    TargetConnectionPointId = 1
            //});
            //logicCore.Graph.AddEdge(new SampleDataEdge
            //{
            //    ID = 7,
            //    Source = q5,
            //    SourceConnectionPointId = 4,
            //    Target = q7,
            //    TargetConnectionPointId = 1
            //});
            //logicCore.Graph.AddEdge(new SampleDataEdge
            //{
            //    ID = 8,
            //    Source = q6,
            //    SourceConnectionPointId = 5,
            //    Target = q7,
            //    TargetConnectionPointId = 1
            //});

            Graph.LogicCore = logicCore;

            //set positions 
            var posList = new Dictionary<SampleDataVertex, Point>
            {
                {logicCore.Graph.Vertices.ToList()[0], new Point(0, 0)},
                {logicCore.Graph.Vertices.ToList()[1], new Point(0, 80)},
                {logicCore.Graph.Vertices.ToList()[2], new Point(-100, 150)},
                {logicCore.Graph.Vertices.ToList()[3], new Point(0, 220)},
                {logicCore.Graph.Vertices.ToList()[4], new Point(0, 290)},
                //{logicCore.Graph.Vertices.ToList()[5], new Point(-100, 360)},
                //{logicCore.Graph.Vertices.ToList()[6], new Point(0, 410)},
            };

            Graph.PreloadGraph(posList);
            
            Graph.SetVerticesDrag(true, true);
            ZoomCtrl.ZoomToFill();
        }
    }
}
