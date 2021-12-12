/* Author: Kamrin Aubin:
 * Last Modified: December 12, 2021
 * Description: Helper class for VideoGame when using the entity framework
 *              Views DbContext contructor to help create CRUD operations for 
 *              all DbSets
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace NETDLab5.Models
{
    public class VideoGameContext : DbContext
    {
        // Constructor for VideoGameContext
        public VideoGameContext(DbContextOptions<VideoGameContext> options) : base(options)
        {

        }

        // Helps us run a command to take care of CRUD operations for all models (VideoGame, VideoGameConsole, Store)
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<VideoGameConsole> VideoGameConsole { get; set; }
        public DbSet<Store> Stores { get; set; }

    }
}
