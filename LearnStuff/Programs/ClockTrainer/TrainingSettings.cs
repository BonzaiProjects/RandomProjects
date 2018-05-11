using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockTrainer
{
    public enum EasyFives
    {
        Zero = 0,
        Five = 5,
        Ten = 10,
        Fifteen = 15,
        Twenty = 20,
        Twentyfive = 25,
        Thirty = 30,
        Thirtyfive = 35,
        Forty = 40,
        Fortyfive = 45,
        Fifty = 50,
        Fiftyfive = 55,
        Sixty = 0
    }

    public class TrainingSettings
    {
        public bool UseSeconds { get; set; }
        public List<EasyFives> UseFives { get; private set; }
        public bool UseAllNumbers { get; set; }

        //private List<EasyFives> AllFives = new List<EasyFives>();
        private Random rand = new Random();

        public TrainingSettings()
        {
            UseFives = new List<EasyFives>();
            UseSeconds = false;
            UseAllNumbers = false;
            FillAllFives();
        }

        private void FillAllFives()
        {
            UseFives.Clear();

            foreach (EasyFives item in Enum.GetValues(typeof(EasyFives)))
            {
                UseFives.Add(item);
            }

        }

        public void UseAllFivesOnlyOrClear(bool status)
        {
            if (status)
            {
                FillAllFives();
            }
            else
            {
                UseFives.Clear();
            }
        }

        public void AddFiveToUse(EasyFives fiveToUse)
        {
            if (!UseFives.Contains(fiveToUse))
            {
                UseFives.Add(fiveToUse);
            }
        }

        public void RemoveFiveToUse(EasyFives fiveToUse)
        {
            if (UseFives.Contains(fiveToUse))
            {
                UseFives.Remove(fiveToUse);
            }
        }

        public DateTime CreateTrainingSession()
        {
            int hour = rand.Next(1, 13);
            int minute = 0;
            int second = 0;

            // random assignment
            if (UseAllNumbers)
            {
                minute = rand.Next(0, 60);

                if (UseSeconds)
                {
                    second = rand.Next(0, 60);
                }
            }
            else
            {
                int temp = rand.Next(0, UseFives.Count);

                minute = (int)UseFives[temp];

                if (UseSeconds)
                {
                    temp = rand.Next(0, UseFives.Count);

                    second = (int)UseFives[temp];
                }
            }

            DateTime date = DateTime.Now;
            return new DateTime(date.Year, date.Month, date.Day, hour, minute, second);
        }
    }
}
