using System;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IInputService _inputService;

        [Inject]
        public void Constructor(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
