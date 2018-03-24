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
        public List<SetWithSetPartDto> Sets { get; set; }
        public SetsDataStore()
        {
            //initialize example data
            Sets = new List<SetWithSetPartDto>()
            {
                new SetWithSetPartDto()
                {
                    SetNumber = "70612-1",
                    Name = "Green Ninja Mech Dragon",
                    ThemeId = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    SetImageUrl = "https://m.rebrickable.com/media/sets/70612-1.jpg"
                },
                new SetWithSetPartDto()
                {
                    SetNumber = "70614-1",
                    Name = "Lightning Jet",
                    ThemeId = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    SetImageUrl = "https://m.rebrickable.com/media/sets/70614-1.jpg"
                },
                new SetWithSetPartDto()
                {
                    SetNumber = "70608-1",
                    Name = "Master Falls",
                    ThemeId = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    SetImageUrl = "https://m.rebrickable.com/media/sets/70608-1.jpg"
                },
                new SetWithSetPartDto()
                {
                    SetNumber = "70611-1",
                    Name = "Water Strider",
                    ThemeId = 616,
                    Theme = "Ninjago > Ninjago The Movie",
                    SetImageUrl = "https://m.rebrickable.com/media/sets/70611-1.jpg",
                    Parts = new List<SetPartDto>()
                    {
                        new SetPartDto()
                        {
                            Id =1244846,
                            PartNumber = "11090",
                            Name = "Bar Holder with Clip",
                            PartUrl = "https://rebrickable.com/parts/11090/bar-holder-with-clip/",
                            PartImageUrl = "https://m.rebrickable.com/media/parts/elements/6015891.jpg",
                            Color = "Black",
                            QuantityNeeded = 3,
                            ElementId = "6015891"
                        },
                        new SetPartDto()
                        {
                            Id =1244817,
                            PartNumber = "43093",
                            Name = "Technic Axle Pin with Friction Ridges Lengthwise",
                            PartUrl = "https://rebrickable.com/parts/43093/technic-axle-pin-with-friction-ridges-lengthwise/",
                            PartImageUrl = "https://m.rebrickable.com/media/parts/elements/4184170.jpg",
                            Color = "Blue",
                            QuantityNeeded = 6,
                            ElementId = "4206482"
                        },
                        new SetPartDto()
                        {
                            Id =1244841,
                            PartNumber = "6141",
                            Name = "Plate Round 1 x 1 with Solid Stud",
                            PartUrl = "https://rebrickable.com/parts/6141/plate-round-1-x-1-with-solid-stud/",
                            PartImageUrl = "https://m.rebrickable.com/media/parts/elements/614126.jpg",
                            Color = "Flat Silver",
                            QuantityNeeded = 4,
                            ElementId = "4633691"
                        },
                        new SetPartDto()
                        {
                            Id =1244855,
                            PartNumber = "92947",
                            Name = "Brick, Round 2 x 2 [Grill]",
                            PartUrl = "https://rebrickable.com/parts/92947/brick-round-2-x-2-grill/",
                            PartImageUrl = "https://m.rebrickable.com/media/parts/elements/6024730.jpg",
                            Color = "Light Bluish Gray",
                            QuantityNeeded = 1,
                            ElementId = "4650645"
                        }
                    }
                },
                new SetWithSetPartDto()
                {
                    SetNumber = "70656-1",
                    Name = "garmadon, Garmadon, GARMADON!",
                    ThemeId = 435,
                    Theme = "Ninjago",
                    SetImageUrl = "https://m.rebrickable.com/media/sets/70656-1.jpg"
                }
            };
        }
    }
}
