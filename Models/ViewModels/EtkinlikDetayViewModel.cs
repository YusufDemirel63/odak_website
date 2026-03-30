using OdakMVC.Models.Entities;
namespace OdakMVC.Models.ViewModels
{
    public class EtkinlikDetayViewModel
    {
        public Etkinlik Etkinlik { get; set; } = new();
        public List<Etkinlik> DigerEtkinlikler { get; set; } = new();
    }
}
