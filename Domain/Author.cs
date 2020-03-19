using System;
using System.Collections.Generic;

namespace Domain {
    public class Author {
        private string id;
        private readonly List<Book> books;

        public Author(string name) {
            id = Guid.NewGuid().ToString("D");
            books = new List<Book>();
            Name = name;
        }

        public string Name { get; private set; }

        public RecommendationScore RecommendationScore { get; private set; }

        public AuthorStatus Status { get; private set; }

        public IReadOnlyList<Book> Books => books;
    }
}