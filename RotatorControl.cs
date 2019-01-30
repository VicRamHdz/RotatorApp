using System;
using System.Collections.Generic;
using System.Windows.Input;
using RotatorApp.Swipe;
using Xamarin.Forms;

namespace RotatorApp
{
    public class RotatorControl : Grid, ISwipeCallBack
    {
        //Label lbl_result;

        Label lbl_first;
        Label lbl_secound;
        Label lbl_third;
        Label lbl_fourth;
        Label lbl_fifth;

        StackLayout layout;
        ScrollView scroll;

        public ICommand Appearing { get; set; }

        //int[] positions;
        Dictionary<string, int> positions;
        Dictionary<string, int> rotations;
        Dictionary<string, int> opacities;

        public RotatorControl()
        {

            //lbl_result = new Label(){ HeightRequest = 30, BackgroundColor = Color.Red, HorizontalTextAlignment = TextAlignment.Center, 
                //HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.EndAndExpand };

            lbl_first = new Label()
            {
                HeightRequest = 70,
                Text = "lbl_first",
                BackgroundColor = Color.Red,
                //VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lbl_secound = new Label()
            {
                HeightRequest = 70,
                Text = "lbl_secound",
                BackgroundColor = Color.Accent,
                //VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lbl_third = new Label()
            {
                HeightRequest = 70,
                Text = "lbl_third",
                BackgroundColor = Color.Brown,
                //VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lbl_fourth = new Label()
            {
                HeightRequest = 70,
                Text = "lbl_fourth",
                BackgroundColor = Color.BlueViolet,
                //VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lbl_fifth = new Label() { 
                HeightRequest = 70,
                Text = "lbl_fifth",
                BackgroundColor = Color.Coral, 
                //VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center, 
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            SwipeListener swipeListener = new SwipeListener(this, this);

            this.RowDefinitions = new RowDefinitionCollection()
            {
                new RowDefinition(){ Height = GridLength.Star },
                new RowDefinition(){ Height = GridLength.Auto }
            };

            //lbl_first.TranslationY = positions[nameof(lbl_first)];
            //lbl_secound.TranslationY = positions[nameof(lbl_secound)];
            //lbl_third.TranslationY = positions[nameof(lbl_third)];
            //lbl_fourth.TranslationY = positions[nameof(lbl_fourth)];
            //lbl_fifth.TranslationY = positions[nameof(lbl_fifth)];

            layout = new StackLayout(){ Spacing = 0, Margin = 15,
                VerticalOptions= LayoutOptions.Center, 
                HorizontalOptions = LayoutOptions.FillAndExpand};

            layout.Children.Add(lbl_first);
            layout.Children.Add(lbl_secound);
            layout.Children.Add(lbl_third);
            layout.Children.Add(lbl_fourth);
            layout.Children.Add(lbl_fifth);

            //positions = new Dictionary<string, int>();
            //positions.Add(nameof(lbl_first), -60);
            //positions.Add(nameof(lbl_secound), -30);
            //positions.Add(nameof(lbl_third), 0);
            //positions.Add(nameof(lbl_fourth), 30);
            //positions.Add(nameof(lbl_fifth), 60);

            //rotations = new Dictionary<string, int>();
            //rotations.Add(nameof(lbl_first), 70);
            //rotations.Add(nameof(lbl_secound), 40);
            //rotations.Add(nameof(lbl_third), 0);
            //rotations.Add(nameof(lbl_fourth), -40);
            //rotations.Add(nameof(lbl_fifth), -70);

            //lbl_first.RotationX = rotations[nameof(lbl_first)];
            //lbl_secound.RotationX = rotations[nameof(lbl_secound)];
            //lbl_third.RotationX = rotations[nameof(lbl_third)];
            //lbl_fourth.RotationX = rotations[nameof(lbl_fourth)];
            //lbl_fifth.RotationX = rotations[nameof(lbl_fifth)];

            scroll = new ScrollView();
            scroll.Content = layout;
            scroll.Scrolled += OnScrolled;
            this.Children.Add(scroll, 0, 0);
            //this.Children.Add(lbl_secound, 0, 0);
            //this.Children.Add(lbl_third, 0, 0);
            //this.Children.Add(lbl_fourth, 0, 0);
            //this.Children.Add(lbl_fifth, 0, 0);

            //this.Children.Add(lbl_result,0,1);

            Appearing = new Command(() => OnAppearing());

        }
        private bool isReording = false;

        private void OnScrolled(object sender, ScrolledEventArgs e)
        {

            //Console.WriteLine(scroll.ScrollY);

            //foreach (Label item in layout.Children)
            //{
                //Console.WriteLine("---");
                //Console.WriteLine(item.Text);
                //Console.WriteLine(item.Y);
                //if (item.Y <= 30)
                //{
                //    item.RotationX = -40;
                //}
                //else if (item.Y <= 150)
                //    item.RotationX = 40;
                //else item.RotationX = 0;
                //else if (item.Y > 90 && item.Y <= 150)
                //    item.RotationX = 0;
                //else if (item.Y > 150 && item.Y <= 200)
                //    item.RotationX = 70;
                //else if (item.Y > 200)
                    //item.RotationX = 90;
            //}

            if (isReording) return;

            foreach (Label item in layout.Children)
            {
                if (item.Y < scroll.ScrollY)
                {
                    isReording = true;
                    item.FadeTo(0, 100, Easing.SinOut);
                    layout.Children.Remove(item);
                    item.FadeTo(1, 100, Easing.SinIn);
                    layout.Children.Add(item);
                    break;
                }
            }

            layout.Children[0].RotationX = 40;
            //layout.Children[0].RotateXTo(40, 0);

            (layout.Children[0] as Label).Margin = new Thickness(40, 0, 40, -10);

            layout.Children[1].RotationX = 35;
            //layout.Children[1].RotateXTo(35, 0);
            (layout.Children[1] as Label).Margin = new Thickness(23, 0, 23, 0);

            layout.Children[2].RotationX = 0;
            (layout.Children[2] as Label).Margin = new Thickness(15, 0, 15, 0);

            layout.Children[3].RotationX = -35;
            //layout.Children[3].RotateXTo(-35, 0);
            (layout.Children[3] as Label).Margin = new Thickness(23, 0, 23, 0);

            layout.Children[layout.Children.Count - 1].RotationX = -40;
            //layout.Children[layout.Children.Count - 1].RotateXTo(-40, 0);
            (layout.Children[layout.Children.Count - 1] as Label).Margin = new Thickness(40, -10, 40, 0);
            isReording = false;
            //if(lbl_first.Y<scroll.ScrollY)
            //{
            //    isReording = true;
            //    layout.Children.Remove(lbl_first);
            //    layout.Children.Add(lbl_first);
            //}else
            //if (lbl_secound.Y < scroll.ScrollY)
            //{
            //    isReording = true;
            //    layout.Children.Remove(lbl_secound);
            //    layout.Children.Add(lbl_secound);
            //}else
            //if (lbl_third.Y < scroll.ScrollY)
            //{
            //    isReording = true;
            //    layout.Children.Remove(lbl_third);
            //    layout.Children.Add(lbl_third);
            //}else
            //if (lbl_fourth.Y < scroll.ScrollY)
            //{
            //    isReording = true;
            //    layout.Children.Remove(lbl_fourth);
            //    layout.Children.Add(lbl_fourth);
            //}else
            //if (lbl_fifth.Y < scroll.ScrollY)
            //{
            //    isReording = true;
            //    layout.Children.Remove(lbl_fifth);
            //    layout.Children.Add(lbl_fifth);
            //}
            //isReording = false;
        }

        private void OnAppearing()
        {
            
        }

        public void onBottomSwipe(View view)
        {
            //lbl_result.Text = "OnBottomSwipe";
        }

        public void onLeftSwipe(View view)
        {
            //lbl_result.Text = "onLeftSwipe";
        }

        public void onNothingSwiped(View view)
        {
            //lbl_result.Text = "onNothingSwiped";
        }

        public void onRightSwipe(View view)
        {
            //lbl_result.Text = "onRightSwipe";
        }

        public async void onTopSwipe(View view)
        {
                //lbl_result.Text = "onTopSwipe";
            //await lbl_first.TranslateTo(0, -50, 500, Easing.SinOut);
            //lbl_first.RotationX = 30;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

        }
    }
}
