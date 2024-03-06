using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        private ParticleSystem vfx;
        [SerializeField] private List<VFXData> vfxData = new List<VFXData>();
        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(VFXType typeToSearch, Vector2 positionToSet)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = positionToSet;
            foreach (VFXData item in vfxData)
            {
                if (item.vfxType == typeToSearch)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    vfx = item.particleSystem;
                }
                else
                {
                    item.particleSystem.gameObject.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if (vfx != null && vfx.isStopped)
            {
                vfx.gameObject.SetActive(false);
                vfx = null;
                controller.ReturnVFXToPool();
                gameObject.SetActive(false);
            }
        }
    }
    [Serializable]
    public class VFXData
    {
        public VFXType vfxType;
        public ParticleSystem particleSystem;
    }
}