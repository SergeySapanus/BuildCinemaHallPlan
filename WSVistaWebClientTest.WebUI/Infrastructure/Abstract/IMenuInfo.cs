using System.Collections.Generic;
using WSVistaWebClientTest.Domain.Entities;
using WSVistaWebClientTest.WebUI.Infrastructure.Concrete;

namespace WSVistaWebClientTest.WebUI.Infrastructure.Abstract
{
    public interface IMenuInfo
    {
        IEnumerable<MenuItemType> Items { get; }
    }
}