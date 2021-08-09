using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public int butt;

        public List<int> pool = new List<int>();


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
            Button6.Clicked += Button6_Clicked;
        }

        private void Button6_Clicked(object sender, EventArgs e)
        {
            Blink();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            inGame(1);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            inGame(2);
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            inGame(3);
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            inGame(4);
        }

        private void Button5_Clicked(object sender, EventArgs e)
        {
            Button5.IsEnabled = false;
            start();

        }

        async void start()
        {
            if (level > 1) await Task.Delay(2000);
            for (int i = 1; i <= level; i++)
            {
                butt = rand.Next(1, 5);
                switch (butt)
                {
                    case 1:
                        pool.Add(1);
                        Button1.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button1.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        break;
                    case 2:
                        pool.Add(2);
                        Button2.BackgroundColor = Xamarin.Forms.Color.Red;

                        await Task.Delay(250);
                        Button2.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        break;
                    case 3:
                        pool.Add(3);
                        Button3.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button3.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250); ;
                        break;
                    case 4:
                        pool.Add(4);
                        Button4.BackgroundColor = Xamarin.Forms.Color.Red;
                        await Task.Delay(250);
                        Button4.BackgroundColor = Xamarin.Forms.Color.Yellow;
                        await Task.Delay(250);
                        break;
                }
                ButtEn();
                await Task.Delay(600);
            }
        }


        async void Blink()
        {
            await Flashlight.TurnOnAsync();
            await Task.Delay(100);
            await Flashlight.TurnOffAsync();
        }

        public void inGame(int butt)
        {
            if (butt == pool.First())
            {
                if (pool.Count() > 1)
                {
                    pool.RemoveAt(0);
                }
                else
                {
                    pool.Clear();
                    level++;
                    start();
                }
            }
            else
            {
                if (level > maxLvl) maxLvl = level - 1;
                pool.Clear();
                level = 1;
                Label_result.Text = Convert.ToString(maxLvl);
                Button5.IsEnabled = true;
                ButtDs();
            }
        }


        public void ButtEn()
        {
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
        }


        public void ButtDs()
        {
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
        }
    }
}
