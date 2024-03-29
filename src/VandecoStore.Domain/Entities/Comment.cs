﻿namespace VandecoStore.Domain.Entities
{
    public class Comment : EntityValidation
    {
        private string _title;
        public required string Title
        {
            get => _title;
            init
            {
                FailIfNullOrEmpty(value, nameof(Title));
                _title = value;
            }
        }
        private string _text;
        public required string Text
        {
            get => _text;
            init
            {
                FailIfNullOrEmpty(value, nameof(Text));
                _text = value;
            }
        }

        public required Product Product { get; init; }
        public required User User { get; init; }

        public Comment() { }
    }
}
