using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Schedule_MultipleResource
{
    [Preserve(AllMembers = true)]
    public class Meeting
    {
        public string EventName { get; set; }
        public string Organizer { get; set; }
        public string ContactID { get; set; }
        public int Capacity { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Color Color { get; set; }
        public double MinimumHeight { get; set; }
        public bool IsAllDay { get; set; }
        public string StartTimeZone { get; set; }
        public string EndTimeZone { get; set; }
        public ObservableCollection<object> Resources { get; set; }
    }

    public class Employees : INotifyPropertyChanged
    {
        private string name;
        private object id;
        private Color color;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.OnPropertyChanged("Name");
            }
        }
        public object ID
        {
            get { return id; }
            set
            {
                id = value;
                this.OnPropertyChanged("ID");
            }
        }

        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                this.OnPropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}