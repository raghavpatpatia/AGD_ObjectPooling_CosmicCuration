using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool vfxPool;
        public VFXService(VFXView vfxView) => vfxPool = new VFXPool(vfxView);
        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXController vfxToPlay = vfxPool.GetVFX();
            vfxToPlay.Configure(type, spawnPosition);
        }
        public void ReturnVFX(VFXController vfxController) => vfxPool.ReturnItem(vfxController);
    } 
}