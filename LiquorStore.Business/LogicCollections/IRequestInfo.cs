using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.Business.Dtos.Auth;

namespace LiquorStore.Business.LogicCollections
{
    public interface IRequestInfo
    {
        RequestInformationOutputDto Current { get; }

        void SetCurrent(RequestInformationOutputDto requestInfo);
    }
}
