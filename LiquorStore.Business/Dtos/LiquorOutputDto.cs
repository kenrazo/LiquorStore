using System;
using System.Collections.Generic;
using System.Text;

namespace LiquorStore.Business.Dtos
{
    public class LiquorOutputDto
    {
        public int LiquorId { get; set; }
        public string LiquorName { get; set; }
        public string LiquorType { get; set; }
    }
}
