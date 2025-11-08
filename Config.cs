using Exiled.API.Interfaces;
using ScpBalancer.Handlers;
using YamlDotNet.Serialization;

namespace ScpBalancer
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        
        public Scp096 Scp096 { get; set; } = new Scp096();
        public Scp049 Scp049 { get; set; } = new Scp049();
        public Scp173 Scp173 { get; set; } = new Scp173();
        public Scp106 Scp106 { get; set; } = new Scp106();
        public Scp939 Scp939 { get; set; } = new Scp939();
    }
}