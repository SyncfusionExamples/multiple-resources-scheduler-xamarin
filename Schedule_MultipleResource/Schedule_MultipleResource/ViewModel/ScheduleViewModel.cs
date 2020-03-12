using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Schedule_MultipleResource
{

	[Preserve(AllMembers = true)]
    public class ScheduleViewModel : INotifyPropertyChanged
    {

        private List<string> currentDayMeetings;

        private List<Color> colorCollection;

        private List<int> startHours;

        private ObservableCollection<Meeting> listOfMeeting;

        private List<string> nameCollection;

        private ObservableCollection<object> resources;
        
        private ObservableCollection<object> selectedResources;
        public DataTemplate WithResource { get; set; }
        public ScheduleViewModel()
        {
            this.ListOfMeeting = new ObservableCollection<Meeting>();
            Resources = new ObservableCollection<object>();
            SelectedResources = new ObservableCollection<object>();
            this.InitializeDataForBookings();
            this.InitializeResources();
            this.BookingAppointments();

            WithResource = new DataTemplate(() =>
            {
                return  new WithResource(); 
            });
        }

        private void InitializeResources()
        {
            Random random = new Random();
            for (int i = 0; i < 14; i++)
            {
                Employees employees  = new Employees();
                employees.Name = nameCollection[i];
                employees.Color = Color.FromRgb(random.Next(0, 255), random.Next(10, 255), random.Next(100, 255));
                employees.ID = i.ToString();

                Resources.Add(employees);
            }

            for (int i = 0; i < 10; i++)
            {
                SelectedResources.Add(Resources[random.Next(Resources.Count)]);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Meeting> ListOfMeeting
        {
            get
            {
                return this.listOfMeeting;
            }

            set
            {
                this.listOfMeeting = value;
                this.RaiseOnPropertyChanged("ListOfMeeting");
            }
        }

        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
                this.RaiseOnPropertyChanged("Resources");
            }
        }

        public ObservableCollection<object> SelectedResources
        {
            get
            {
                return selectedResources;
            }

            set
            {
                selectedResources = value;
                this.RaiseOnPropertyChanged("selectedResources");
            }
        }
        internal void BookingAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 3; additionalAppointmentIndex++)
                    {
                        Meeting meeting = new Meeting();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, this.startHours[randomTime.Next(0, 2)], 0, 0);
                        meeting.To = meeting.From.AddHours(12);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employees).ID
                            };
                        meeting.Resources = coll;


                        this.ListOfMeeting.Add(meeting);
                    }
                }
                else
                {
                    Meeting meeting = new Meeting();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(4);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.IsAllDay = true;
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    var coll = new ObservableCollection<object>
                            {
                                (resources[randomTime.Next(Resources.Count)] as Employees).ID
                            };
                    meeting.Resources = coll;
                    this.ListOfMeeting.Add(meeting);
                }
            }
        }
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            this.colorCollection = new List<Color>();
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF1BA1E2"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFA2C139"));
            this.colorCollection.Add(Color.FromHex("#FFD80073"));
            this.colorCollection.Add(Color.FromHex("#FF339933"));
            this.colorCollection.Add(Color.FromHex("#FFE671B8"));
            this.colorCollection.Add(Color.FromHex("#FF00ABA9"));

            this.nameCollection = new List<string>();
            this.nameCollection.Add("Brooklyn");
            this.nameCollection.Add("James William");
            this.nameCollection.Add("Stephen");
            this.nameCollection.Add("Zoey Addison");
            this.nameCollection.Add("Daniel");
            this.nameCollection.Add("Emilia");
            this.nameCollection.Add("Adeline Ruby");
            this.nameCollection.Add("Kinsley Elena");
            this.nameCollection.Add("Danial William");
            this.nameCollection.Add("Stephen Addison");
            this.nameCollection.Add("Kinsley Ruby");
            this.nameCollection.Add("Adeline Elena");
            this.nameCollection.Add("Emilia William");
            this.nameCollection.Add("Danial Addison");

            this.startHours = new List<int>();
            this.startHours.Add(0);
            this.startHours.Add(12);
            this.startHours.Add(12);
        }
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}