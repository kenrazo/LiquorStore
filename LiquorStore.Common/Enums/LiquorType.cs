using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LiquorStore.Common.Enums
{
    public enum LiquorType
    {
        [Description("Whiskey")]
        Whiskey = 1,
        [Description("Beer")]
        Beer = 2,
        [Description("Brandy")]
        Brandy = 3
    }
}
