﻿using WigeDev.Init.Interfaces;
using WigeDev.ViewModel.Interfaces;
using WigeDev.ViewModel.Implementations;

namespace WigeDev.Init.Implementations
{
    public class TextFieldInitializer : IInitializer<IDictionary<string, ITextField>>
    {
        public IDictionary<string, ITextField> Initialize()
        {
            var dictionary = new Dictionary<string, ITextField>();
            dictionary.Add("source", new TextField());
            dictionary.Add("destination", new TextField());
            return dictionary;
        }
    }
}
