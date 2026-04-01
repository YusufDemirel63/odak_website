using OdakMVC.Models.Entities;

namespace OdakMVC.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Etkinlik> SonEtkinlikler { get; set; } = new();
        public List<SliderGorseli> Sliderlar { get; set; } = new();
        public List<Kulup> Kulupler { get; set; } = new();
        public IcerikSayfasi? HakkimizdaOzeti { get; set; }
        public List<Egitim> SonEgitimler { get; set; } = new();
    }
}
