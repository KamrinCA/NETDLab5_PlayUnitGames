/* Author: Kamrin Aubin
 * Last Modified: December 12, 2021
 * Description: Video Game Console Class. Contains all member variables for the class.
 *              Plus, includes a foreign key by adding a storeID and a store 
 *              member variable.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETDLab5.Models
{
    public class VideoGameConsole
    {
        // Member variables for VideoGameConsole
        public int videoGameConsoleID { get; set; }

        public string brand { get; set; }

        public string name { get; set; }

        public string manufacturer { get; set; }

        public bool isNew { get; set; }

        // Used to set a foreign key with Store class. Entity Framework automatically takes care of it.
        public int storeID { get; set; }
        public Store store { get; set; }

    }
}
