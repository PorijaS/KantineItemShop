using Kantine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kantine.Services
{
    internal class VMService
    {
        static VMService _instance;

        public static VMService instance
        {
            get
            {
                _instance ??= new VMService();

                return _instance;
            }
        }

        public readonly VM VM1 = new VM
        {
            VMName = "Pølsehorn",
            VMImageUrl = "https://mambeno.dk/wp-content/uploads/2020/04/Klassiske-poelsehorn-scaled.jpg"
        };

        public readonly VM VM2 = new VM
        {
            VMName = "Burger",
            VMImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/shroomami-burger-3-1655147735.jpg"
        };

        public readonly VM VM3 = new VM
        {
            VMName = "Pizza",
            VMImageUrl = "https://madogkaerlighed.dk/wp-content/uploads/2020/03/IMG_3793-scaled.jpg"
        };

        public readonly VM VM4 = new VM
        {
            VMName = "Kylling på spyd",
            VMImageUrl = "https://www.onekitchenblog.com/wp-content/uploads/2019/07/IMG_5799.jpg"
        };

        public readonly VM VM5 = new VM
        {
            VMName = "Placeholder",
            VMImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png"
        };

        public readonly VM VM6 = new VM
        {
            VMName = "Placeholder",
            VMImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png"
        };

        public List<VM> GetVMS()
        {
            return new List<VM>
            {
                VM1, VM2, VM3, VM4, VM5, VM6
            };
        }
    }
}
