namespace Sushi
{
    using System.ComponentModel;

    public class SushiOrder: INotifyPropertyChanged
    {
        private string name;
        private int quantity;
        private int number;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if(value<0)
                {
                    quantity = 0;
                }
                else
                {
                    quantity = value;
                }
                OnPropertyChanged("Quantity");
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 0)
                {
                    number = 0;
                }
                else
                {
                    number = value;
                }
                OnPropertyChanged("Number");
            }
        }

        public SushiOrder()
        {
            Name = "None";
            Quantity = 0;
            Number = 0;
        }

        public SushiOrder(string _name,int _quantity,int _number)
        {
            Name = _name;
            Quantity = _quantity;
            Number = _number;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
            { 
                 PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

    }
}
