using System;
using System.Collections.Generic;

namespace Domain {
    public class Author {
        private string id;
        private readonly HashSet<Book> books;

        public Author(string name) {
            id = Guid.NewGuid().ToString("D");
            books = new HashSet<Book>();
            Name = name;
        }

        public string Name { get; private set; }

        public RecommendationScore RecommendationScore { get; private set; }

        public AuthorStatus Status { get; private set; }

        public IReadOnlyCollection<Book> Books => books;

        public void UpdateName(string name) {
            // logic to ensure the name is valid
            Name = name;
        }
        
        public void AddBook(Book book) {
            // Some logic to handle whether a book
            // can be added or not
            books.Add(book);
        }

        public void RemoveBook(Book book) {
            // Logic
            books.Remove(book);
        }

        public void UpdateScore(RecommendationScore score) {
            // logic
            RecommendationScore = score;
        }
    }
}