namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;

    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //Console.WriteLine(ExportAlbumsInfo(context, 9)); -- Exercise 2
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        //Exercise 2
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder output = new StringBuilder();

            var albumsInfo = context
                .Albums
                .Where(a => a.ProducerId.Value == producerId)          //Adding .Value, as the ProducedId is Nullable, and a problem may arise
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        Price = s.Price,
                        Writer = s.Writer.Name,
                    })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    TotalPrice = a.Price
                })
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();

            foreach (var a in albumsInfo)
            {
                output
                    .AppendLine($"-AlbumName: {a.AlbumName}")
                    .AppendLine($"-ReleaseDate: {a.ReleaseDate}")
                    .AppendLine($"-ProducerName: {a.ProducerName}")
                    .AppendLine($"-Songs:");

                int songCounter = 1;
                foreach (var s in a.Songs)
                {
                    output
                        .AppendLine($"---#{songCounter++}")
                        .AppendLine($"---SongName: {s.SongName}")
                        .AppendLine($"---Price: {s.Price:F2}")
                        .AppendLine($"---Writer: {s.Writer}");
                }

                output
                    .AppendLine($"-AlbumPrice: {a.TotalPrice:F2}");
            }

            return output.ToString().TrimEnd();
        }

        //Exercise 3
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder output = new StringBuilder();

            var songsInfo = context
                .Songs
                //.Include(s => s.SongPerformers)
                //.ThenInclude(sp => sp.Performer)
                //.Include(s => s.Writer)
                //.Include(s => s.Album)
                //.ThenInclude(a => a.Producer)
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ThenBy(s => s.PerformerFullName)
                .ToArray();

            int songCounter = 1;
            foreach(var s in songsInfo)
            {
                output
                    .AppendLine($"-Song #{songCounter++}")
                    .AppendLine($"---SongName: {s.SongName}")
                    .AppendLine($"---Writer: {s.WriterName}")
                    .AppendLine($"---Performer: {s.PerformerFullName}")
                    .AppendLine($"---AlbumProducer: {s.AlbumProducer}")
                    .AppendLine($"---Duration: {s.Duration}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
