using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntertainmentLibrary.Models;

namespace EntertainmentLibrary.Data
{
    public class EntertainmentLibraryContext : DbContext
    {
        public EntertainmentLibraryContext (DbContextOptions<EntertainmentLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<EntertainmentLibrary.Models.MediaModel> MediaModel { get; set; } = default!;
    }
}
