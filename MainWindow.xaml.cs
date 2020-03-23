using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace GoXam
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            MyDiagram.Model = new MyModel
            {
                NodesSource = new ObservableCollection<MyNode>(),
                LinksSource = new ObservableCollection<MyLink>(),
                Modifiable = true
            };

            MyPalette.Model = new MyModel
            {
                NodesSource = new ObservableCollection<MyNode>
                {
                    new MyNode {Key = "Start"}, 
                    new MyNode {Key = "End"}
                }
            };
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var model = MyDiagram.Model as MyModel ?? new MyModel();
            var modelAsXml = model.Save<MyNode, MyLink>(nameof(MainWindow), nameof(MyNode), nameof(MyLink));
            var document = new XmlDocument();
            document.LoadXml(modelAsXml.ToString());
            var modelAsJson = JsonConvert.SerializeXmlNode(document, Formatting.Indented);
            MessageBox.Show(modelAsJson);
        }
    }
}