using LegoPartTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoPartTracker.API
{
    public class SetsDataStore
    {
        public static SetsDataStore Current { get; } = new SetsDataStore();
        public List<SetDto> Sets { get; set; }
        public SetsDataStore()
        {
            //initialize example data
            Sets = new List<SetDto>()
            {
                new SetDto()
                {
                    Set_num = "70612-1",
                    Name = "Green Ninja Mech Dragon",
                    Theme_id = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    Set_img_url = "https://m.rebrickable.com/media/sets/70612-1.jpg"
                },
                new SetDto()
                {
                    Set_num = "70614-1",
                    Name = "Lightning Jet",
                    Theme_id = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    Set_img_url = "https://m.rebrickable.com/media/sets/70614-1.jpg"
                },
                new SetDto()
                {
                    Set_num = "70608-1",
                    Name = "Master Falls",
                    Theme_id = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    Set_img_url = "https://m.rebrickable.com/media/sets/70608-1.jpg"
                },
                new SetDto()
                {
                    Set_num = "70611-1",
                    Name = "Water Strider",
                    Theme_id = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    Set_img_url = "https://m.rebrickable.com/media/sets/70611-1.jpg"
                },
                new SetDto()
                {
                    Set_num = "70656-1",
                    Name = "garmadon, Garmadon, GARMADON!",
                    Theme_id = 435,
                    Theme = "Ninjago",
                    Set_img_url = "https://m.rebrickable.com/media/sets/70656-1.jpg"
                }
            };
        }
    }
}
