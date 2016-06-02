﻿using Zebo.Presentation.Common.Commands;

namespace Zebo.Presentation.Common.ModelBase
{
    public interface IEditableCollection
    {
        ICaptionCommand AddItemCommand { get; set; }
        ICaptionCommand EditItemCommand { get; set; }
        ICaptionCommand DeleteItemCommand { get; set; }
    }
}