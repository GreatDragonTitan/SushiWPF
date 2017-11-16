using System;
using System.Collections.Generic;
namespace Sushi
{
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    public class ViewModel: INotifyPropertyChanged
    {
        private string path;
        private SushiOrder selectedOrder;
        private ObservableCollection<SushiOrder> orders;

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public SushiOrder SelectedOrder
        {
            get
            {
                return selectedOrder;
            }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public ObservableCollection<SushiOrder> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        public ViewModel(string _path)
        {
            Path = _path;
            Upload();
        }

        public void Save()
        {
            var lines = new string[Orders.Count];
            for(int i=0;i<lines.Length;++i)
            {
                lines[i]= Orders[i].Name + " " + Orders[i].Quantity;
            }
            File.WriteAllLines(Path, lines);
        }

        public void Delete()
        {
            Orders.Remove((SelectedOrder));
            SelectedOrder = Orders.Count != 0 ? Orders.First() : null;
        }

        public void Upload()
        {
            Orders = new ObservableCollection<SushiOrder>();
            if(!File.Exists(Path))
            {
                throw new Exception("File does not exists.");
            }
            var lines = File.ReadAllLines(Path, Encoding.UTF8);
            string[] line;
            string name;
            int quantity;
            for (int i = 0; i < lines.Length; ++i)
            {
                line = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (line.Length > 1)
                {
                    name = line[0];
                    for (int j = 1; j < line.Length - 1; ++j)
                    {
                        name += " " + line[j];
                    }
                    if (!int.TryParse(line[line.Length - 1], out quantity))
                    {
                        throw new Exception("Cannot parse quantity value.");
                    }

                    Orders.Add(new SushiOrder(name, quantity, Orders.Count + 1));
                }
            }
            if (Orders.Count != 0)
            {
                SelectedOrder = Orders.First();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
