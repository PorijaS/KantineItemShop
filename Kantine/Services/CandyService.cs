using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kantine.Model;

namespace Kantine.Services
{
    public class CandyService
    {
        static CandyService _instance;

        public static CandyService instance
        {
            get
            {
                _instance ??= new CandyService();

                return _instance;
            }
        }

        public readonly Candy Candy1 = new Candy
        {
            CandyName = "Snickers",
            CandyImageUrl = "https://static.wixstatic.com/media/2cd43b_bb9f07f60d434cb39e5bcb1312e982f5~mv2.png/v1/fill/w_320,h_256,q_90/2cd43b_bb9f07f60d434cb39e5bcb1312e982f5~mv2.png"
        };      
        
        public readonly Candy Candy2 = new Candy
        {
            CandyName = "Haribo Goldbears",
            CandyImageUrl = "https://assets.haribo.com/image/upload/s--q8QScoFX--/ar_2700:3661,c_fill,f_auto,q_60/w_763/v1/consumer-sites/international/Goldbears.png"
        };

        public readonly Candy Candy3 = new Candy
        {
            CandyName = "Stimorol Bubble Mint",
            CandyImageUrl = "https://nordicexpatshop.com/media/catalog/product/cache/a75b4628650e2182ad447c229a356118/9/5/95dff8f23cc1b03ba68d65ca384e9140c325b78728e5fb422c0a751a56ecea4b.jpeg"
        };

        public readonly Candy Candy4 = new Candy
        {
            CandyName = "Pringles",
            CandyImageUrl = "https://assets.stickpng.com/images/5954b954deaf2c03413be345.png"
        };

        public readonly Candy Candy5 = new Candy
        {
            CandyName = "Kims American grill",
            CandyImageUrl = "https://iios.dk/wp-content/uploads/2021/02/5650007842-KiMs-Chips-American-Grill-20-x-175g-708x1092-2.png"
        };

        public readonly Candy Candy6 = new Candy
        {
            CandyName = "Maoam",
            CandyImageUrl = "https://m.media-amazon.com/images/I/61hiwuPbheL._AC_.jpg"
        };

        public List<Candy> GetCandies()
        {
            return new List<Candy>
            {
                Candy1, Candy2, Candy3, Candy4, Candy5, Candy6
            };
        }


    }
}
