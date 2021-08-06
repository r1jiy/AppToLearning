using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public int t = 1;
        public int butt;

        public List<int> pool;


        public List<int> result;

        public int level = 1;

        public int maxLvl;
        Random rand = new Random();

        protected override void OnAppearing()
        {
            Button1.Clicked += Button1_Clicked;
            Button2.Clicked += Button2_Clicked;
            Button3.Clicked += Button3_Clicked;
            Button4.Clicked += Button4_Clicked;
            Button5.Clicked += Button5_Clicked;
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {

        }

        private void Button2_Clicked(object sender, EventArgs e)
        {

        }

        private void Button3_Clicked(object sender, EventArgs e)
        {

        }

        private void Button4_Clicked(object sender, EventArgs e)
        {

        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            Button5.IsEnabled = false;
            start();
        }

        async void start()
        {
            for (int i = 1; i <= t; i++)
            {
                butt = rand.Next(1, 5);
                switch (butt)
                {
                    case 1:
                        Button1.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button1.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        pool.Add(1);
                        break;
                    case 2:
                        Button2.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button2.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        pool.Add(2);
                        break;
                    case 3:
                        Button3.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button3.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        pool.Add(3);
                        break;
                    case 4:
                        Button4.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button4.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        pool.Add(4);
                        break;
                }
                await Task.Delay(600);
                if (i == t) Button5.IsEnabled = true;
            }
        }

        public void inGame(int butt)
        {
            if (butt != pool.First())
            {
                if (pool.Count() > 1)
                pool.Remove(0);
                else
                {
                    pool.Clear();



                }
            }
            else
            {


            }
        }
    }
}
