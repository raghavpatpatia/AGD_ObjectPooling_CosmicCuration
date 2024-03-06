using CosmicCuration.Utilities;

namespace CosmicCuration.VFX
{
    public class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxView;
        public VFXPool(VFXView vfxView) => this.vfxView = vfxView;
        public VFXController GetVFX() => GetItem<VFXController>();
        protected override VFXController CreateItem<T>() => new VFXController(vfxView);
    }
}