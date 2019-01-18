using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������ӿ�
    /// </summary>
    public interface IInputService : IPlayerBehaviour
    {
        void Init(Contexts contexts);
        void Update();
    }
    /// <summary>
    /// ��Entitas�������������
    /// </summary>
    public class EntitasInputService : IInputService
    {
        private Contexts _contexts;

        public void Init(Contexts contexts)
        {
            _contexts = contexts;
            _contexts.input.SetGameInputButton(InputButton.NULL);
        }

        public void Update()
        {

        }

        public void AttackO()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.ATTACK_O);
        }

        public void AttackX()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.ATTACK_X);
        }

        public void Back()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.DOWN);
        }

        public void Left()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.LEFT);
        }

        public void Right()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.RIGHT);
        }

        public void Forward()
        {
            _contexts.input.ReplaceGameInputButton(InputButton.UP);
        }
    }

    /// <summary>
    /// ��Unity�������������
    /// </summary>
    public class UnityInputService : IInputService
    {
        private IInputService _entitaInputService;

        public void Init(Contexts contexts)
        {
            _entitaInputService = contexts.game.gameEntitasInputService.EntitasInputService;
        }

        public void Update()
        {
            Forward();

            Back();

            Left();

            Right();

            AttackO();

            AttackX();
            
        }

        public void Forward()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _entitaInputService.Forward();
            }
        }

        public void Back()
        {
            if (Input.GetKey(KeyCode.S))
            {
                _entitaInputService.Back();
            }
        }

        public void Left()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _entitaInputService.Left();
            }
        }

        public void Right()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _entitaInputService.Right();
            }
        }

        public void AttackO()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                _entitaInputService.AttackO();
            }
        }

        public void AttackX()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                _entitaInputService.AttackX();
            }
        }
    }
}