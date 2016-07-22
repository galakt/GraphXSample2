using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphX.Measure;
using GraphX.PCL.Common.Models;

namespace GraphXSample2
{
    public class SampleDataEdge : EdgeBase<SampleDataVertex>, INotifyPropertyChanged
    {
        public override Point[] RoutingPoints { get; set; }

        public SampleDataEdge(SampleDataVertex source, SampleDataVertex target, double weight = 1)
            : base(source, target, weight)
        {
            Angle = 90;
        }

        public SampleDataEdge()
            : base(null, null, 1)
        {
            Angle = 90;
        }

        public bool ArrowTarget { get; set; }

        public double Angle { get; set; }

        private string _text;
        public string Text { get { return _text; } set { _text = value; OnPropertyChanged("Text"); } }
        public string ToolTipText { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
