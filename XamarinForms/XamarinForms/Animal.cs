using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinForms
{
    public class Animal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class AnimalsViewModel
    {
        public ObservableCollection<Animal> Animals { get; } = new ObservableCollection<Animal>();

        public async Task GetAnimals()
        {
            try
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync("http://testapiapp360.azurewebsites.net/api/values");
                var items = JsonConvert.DeserializeObject<List<Animal>>(json);
                foreach (var item in items)
                {
                    Animals.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }
    }
}
