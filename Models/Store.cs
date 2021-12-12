/* Author: Kamrin Aubin:
 * Last Modified: December 12, 2021
 * Description: Stores Class. Contains all member variables for the Store class.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETDLab5.Models
{
    
    public class Store
    {
        // Member variables for Store
        public int storeID { get; set; }

        public string country { get; set; }

        public string city { get; set; }

        public string address { get; set; }

        public string postalCode { get; set; }

        public List<VideoGame> games { get; set; }

        public List<VideoGameConsole> gameConsoles { get; set; }

    }
}
