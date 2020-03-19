using System;

namespace Domain {
    public class Book {
        private string id;

        public Book(string name) {
            id = Guid.NewGuid().ToString("D");
            Name = name;
        }
        
        public string Name { get; private set; }

        public DateTime Released { get; private set; }

        public Author Author { get; private set; }
    }
}