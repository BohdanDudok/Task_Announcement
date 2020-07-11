using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Announcement.Models;

namespace Task_Announcement
{
    public class SampleData
    {
        public static void Initialize(AnnounceContext content)
        {
            if (!content.Announces.Any())
            {
                content.AddRange(
                    new Announce
                    {
                        Title = "First",
                        Description = "good",
                        data = "10.07.20"
                    }
                    );
            }
            content.SaveChanges();
        }
    }
}
