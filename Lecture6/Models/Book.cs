using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lecture6.Models
{
    [JsonObject]
    public class Book
    {
        [JsonProperty]
        public string Author { get; set; }
        [JsonProperty]
        public string Title { get; set; }

        public static IEnumerable<Book> GetBooks()
        {
            yield return new Book { Author = "Роберт Джордан", Title = "Око мира" };
            yield return new Book { Author = "Роберт Джордан", Title = "Великая охота" };
            yield return new Book { Author = "Роберт Джордан", Title = "Дракон возрожденный" };
            yield return new Book { Author = "Роберт Джордан", Title = "Восходящая тень" };

            yield return new Book { Author = "Джордж Мартин", Title = "Игра престолов" };
            yield return new Book { Author = "Джордж Мартин", Title = "Битва королей" };
            yield return new Book { Author = "Джордж Мартин", Title = "Буря мечей" };
            yield return new Book { Author = "Джордж Мартин", Title = "Пир стервятников" };
        }

        public static string[] GetAuthors()
        {
            return new[] { "" }
                .Concat(
                    GetBooks()
                        .Select(z => z.Author)
                        .Distinct())
                .ToArray();
                
        }
    }
}