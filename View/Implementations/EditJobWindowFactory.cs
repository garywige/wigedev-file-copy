﻿using WigeDev.View.Interfaces;

namespace WigeDev.View.Implementations
{
    public class EditJobWindowFactory : IWindowFactory<EditJobWindowAdapter>
    {
        public EditJobWindowAdapter CreateWindow() => new EditJobWindowAdapter();
    }
}
