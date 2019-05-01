using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomHat
{
    public partial class MainPage : ContentPage
    {
        string[] people = new string[] { "Aga", "Matty O", "Pete", "Pipes", "Burak", "Brad", "Johnny", "Neil", "Glassy", "Jase", "Chomp", "Ansel", "Glen", "Shep", "Rob", "Kemo", "Macca", "Dan" };
        Dictionary<string, Switch> toggles = new Dictionary<string, Switch>();
        public MainPage()
        {
            InitializeComponent();

            for(int i = 0; i < people.Length; i++)
            {
                StackLayout sl = new StackLayout() { Orientation = StackOrientation.Horizontal};
                Switch sw = new Switch() { IsToggled = true, StyleId = people[i] };
                Label lb = new Label() { Text = people[i] };
                sl.Children.Add(sw);
                sl.Children.Add(lb);
                
                selectors.Children.Add(sl, i % 2, i / 2);

                toggles.Add(people[i], sw);
            }
            
        }

        private void Button_Clicked(object sender, EventArgs e)
        {            
            result.Text = "Clicked";

            List<string> eligible = new List<string>();

            foreach(var kvp in toggles)
            {
                if (kvp.Value.IsToggled)
                {
                    eligible.Add(kvp.Key);
                }
            }

            var random = new Random();            
            int index = random.Next(eligible.Count);
            result.Text = eligible[index];
        }
    }
}
