using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Pukui.Sound
{
    public class SoundPooler
    {
        Transform _parentTr;
        IObjectPool<SoundController> _pool;

        int MaxSize => SoundSettings.ControllerMaxSize;

        public void Init(Transform root)
        {
            _parentTr = root;
            _pool = new ObjectPool<SoundController>(CreateController, OnGetController, OnReleaseController, OnDestroyController, maxSize: MaxSize);
        }

        public SoundController GetController()
        {
            return _pool.Get();
        }

        SoundController CreateController()
        {
            SoundController sc = new GameObject("SoundController").AddComponent<SoundController>();
            sc.transform.SetParent(_parentTr);
            sc.SetManagedPool(_pool);
            return sc;
        }

        void OnGetController(SoundController sc)
        {
            sc.gameObject.SetActive(true);
        }

        void OnReleaseController(SoundController sc)
        {
            sc.gameObject.SetActive(false);
        }

        void OnDestroyController(SoundController sc)
        {
            Object.Destroy(sc.gameObject);
        }
    }
}