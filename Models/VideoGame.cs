/* Author: Kamrin Aubin:
 * Last Modified: December 12, 2021
 * Description: Video Game Class. Contains all member variables for the class.
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
    public class VideoGame
    {
        // Member variables for VideoGame
        public int videoGameID { get; set; }

        public string name { get; set; }

        public string developer { get; set; }

        public string publisher { get; set; }

        public int yearOfRelease { get; set; }

        public string platform { get; set; }

        public bool isNew { get; set; }

        // Used to set a foreign key with Store class. Entity Framework automatically takes care of it.
        public int storeID { get; set; } 
        public Store store { get; set; }

    }
}
