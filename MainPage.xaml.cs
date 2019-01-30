using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RotatorApp
{
    public partial class MainPage : ContentPage
    {
        public ICommand AppearingCommand { get; set; }

        public ObservableCollection<Data> Values
        {
            get;
            set;
        }

        public List<int> Displayed
        { get; set; }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
            AppearingCommand = new Command(() => { });
            Values = new ObservableCollection<Data>();

            Values.Add(new Data { Title = "item1" });
            Values.Add(new Data { Title = "item2" });
            Values.Add(new Data { Title = "item3" });
            Values.Add(new Data { Title = "item4" });
            Values.Add(new Data { Title = "item5" });
            Values.Add(new Data { Title = "item6" });
            Values.Add(new Data { Title = "item7" });
            Values.Add(new Data { Title = "item8" });
            Values.Add(new Data { Title = "item9" });
            Values.Add(new Data { Title = "item10" });

            Displayed = new List<int>();
            //lstRotator.ItemsSource = Values;

            //lstRotator.ItemAppearing += lstRotator_ItemAppearing;
            //lstRotator.ItemDisappearing += async(sender, e)=> {
                
            //    if (isLoading || Values.Count == 0) return;

            //    isLoading = true;

            //    var currentIdx = Values.IndexOf((Data)e.Item);
            //    await Task.Run(() =>
            //    {
            //        var item = Values[currentIdx];
            //        Values.Insert(Values.Count, item);
            //        Task.Delay(TimeSpan.FromMilliseconds(20));
            //        Values.RemoveAt(currentIdx);
            //        Task.Delay(TimeSpan.FromMilliseconds(20));
            //        Console.WriteLine(currentIdx);
            //        Console.WriteLine(item.Title);
            //        isLoading = false;

            //    });
            //};

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RotatorControl.Appearing.Execute(true);
            //var element = this.Values[0];
            //lstRotator.ScrollTo(element, ScrollToPosition.Center, true);
        }
        private int _lastItemAppearedIdx = 0;
        private bool isLoading;

        private void lstRotator_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            //try
            //{
            //    if (isLoading || Values.Count == 0)
            //        return;
                
            //    var currentIdx = Values.IndexOf((Data)e.Item);

            //    if(currentIdx == Values.IndexOf(Values[Values.Count-1]))
            //    {
            //        LoadItems();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    DisplayAlert("Error", ex.Message, "OK");
            //}


            //Displayed.Add(currentIdx);

            //if (currentIdx > _lastItemAppearedIdx)
            //{
            //    //Console.WriteLine("Up");
            //    ((Data)e.Item).RotateX = ((Data)e.Item).RotateX + 30;
            //}
            //else
            //{
            //    //Console.WriteLine("Down");
            //    ((Data)e.Item).RotateX = ((Data)e.Item).RotateX - 30;
            //}

            //Console.WriteLine(((Data)e.Item).Title);
            //_lastItemAppearedIdx = Values.IndexOf((Data)e.Item);


            //var currentItem = e.Item as Data;
            //Console.WriteLine(currentItem);
            //var lastItem = Values[Values.Count - 1];
            //if (currentItem == lastItem)
            //{

            //}
        }

        private void LoadItems()
        {
            isLoading = true;
            //simulator delayed load
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                foreach (var item in Displayed)
                {
                    Values.Add(Values[item]);
                    Values.RemoveAt(item);
                }
                Displayed.Clear();
                isLoading = false;
                //stop timer
                return false;
            });
        }

        private bool movingItems = false;

        private async Task lstRotator_Disappearing(object sender, ItemVisibilityEventArgs e)
        {
            //if (movingItems) return;
            //movingItems = true;
            //var currentIdx = Values.IndexOf((Data)e.Item);
            //var item = Values[currentIdx];
            //Console.WriteLine(currentIdx);
            //Console.WriteLine(item.Title);
            //Values.Insert(Values.Count, item);
            //Values.RemoveAt(currentIdx);
            //movingItems = false;

            var currentIdx = Values.IndexOf((Data)e.Item);
            if (isLoading || Values.Count == 0) return;

            isLoading = true;
            await Task.Run(() =>
            {
                var item = Values[currentIdx];
                Values.Insert(Values.Count, item);
                //await Task.Delay(TimeSpan.FromMilliseconds(20));
                Values.RemoveAt(currentIdx);
                //await Task.Delay(TimeSpan.FromMilliseconds(20));
                Console.WriteLine(currentIdx);
                Console.WriteLine(item.Title);
                isLoading = false;

            });

            //simulator delayed load
            //Device.StartTimer(TimeSpan.FromSeconds(5), () => {
              
            //    //stop timer
            //    return false;
            //});

            //Values.Insert(Values.Count, ((Data)e.Item));
            //Values.RemoveAt(currentIdx);
            //OnPropertyChanged(nameof(Values));

            //Displayed.Add(currentIdx);

            //if (currentIdx > _lastItemAppearedIdx)
            //{
            //    //Console.WriteLine("Disappearing Up");

            //    ((Data)e.Item).RotateX = ((Data)e.Item).RotateX - 30;
            //}
            //else
            //{            
            //    //Console.WriteLine("Disappearing Down");
            //    ((Data)e.Item).RotateX = ((Data)e.Item).RotateX + 30;
            //}

                //Console.WriteLine(((Data)e.Item).Title);
            //_lastItemAppearedIdx = Values.IndexOf((Data)e.Item);
            //ApplyRotation();
        }

        private void ApplyRotation()
        {
            var count = Displayed.Count;
            if (count > 0)
            {
                var element = this.Values[(int)Displayed[0]];
                Console.WriteLine(element.Title);
            }
        }

    }

    public class Data : INotifyPropertyChanged
    {
        public Data()
        {
            RotateX = 0;
        }

        public string Title
        {
            get;
            set;
        }

        private int _RotateX;
        public int RotateX
        {
            get { return _RotateX; }
            set 
            { 
                _RotateX = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
