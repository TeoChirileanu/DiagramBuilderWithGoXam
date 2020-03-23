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
                Modifiable = true,
                NodeKeyPath = "Key",
                NodeIsGroupPath = "IsSubGraph",
                GroupNodePath = "SubGraphKey"
            };

            MyPalette.Model = new MyModel
            {
                NodesSource = new ObservableCollection<MyNode>
                {
                    new MyNode {Key = "Input", SubGraphKey = "Group"},
                    new MyNode {Key = "Transform", SubGraphKey = "Group"},
                    new MyNode {Key = "Output", SubGraphKey = "Group"},
                    
                    new MyNode {Key = "Group", IsSubGraph = true}
                },
                LinksSource = new ObservableCollection<MyLink>
                {
                    new MyLink {From = "Input", To = "Transform"},
                    new MyLink {From = "Transform", To = "Output"}
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